using System.Reflection;
using MediatR;
using MinimalApiWithMediatr.Common.Filters;

namespace MinimalApiWithMediatr.Common.Extensions;

public static class MediatrExtensions
{
    public static WebApplication MediateGet<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        var (name, groupName) = GetNameAndGroupName<TRequest>();

        app
            .MapGet(template, async ([AsParameters] TRequest request, IMediator mediatr) => await mediatr.Send(request))
            .WithName(name)
            .WithTags(groupName)
            .AddRouteHandlerFilter<ExceptionsFilter<TRequest>>();

        return app;
    }

    public static WebApplication MediatePost<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        var (name, groupName) = GetNameAndGroupName<TRequest>();

        app
            .MapPost(template, async ([AsParameters] TRequest request, IMediator mediatr) => await mediatr.Send(request))
            .WithName(name)
            .WithTags(groupName)
            .AddRouteHandlerFilter<ExceptionsFilter<TRequest>>();

        return app;
    }

    public static WebApplication MapRoutes(this WebApplication app)
    {
        var assembly = Assembly.GetExecutingAssembly();

        app.MapGetEndpointsFromAssembly(assembly);

        app.MapPostEndpointsFromAssembly(assembly);

        return app;
    }

    private static WebApplication MapGetEndpointsFromAssembly(this WebApplication app, Assembly assembly)
    {
        var getEndpoints = assembly.GetExportedTypes().Where(t => t.GetCustomAttribute<QueryAttribute>() != null);

        foreach (var getEndpoint in getEndpoints)
        {
            var template = getEndpoint.GetCustomAttribute<QueryAttribute>()!.Route;

            var method = assembly.GetExportedTypes()
                .SingleOrDefault(x => x.Name == nameof(MediatrExtensions))
                ?.GetMethod(nameof(MediateGet))
                ?.MakeGenericMethod(getEndpoint);
 
            method?.Invoke(assembly, new object?[] { app, template });
        }

        return app;
    }

    private static WebApplication MapPostEndpointsFromAssembly(this WebApplication app, Assembly assembly)
    {
        var postEndpoints = assembly.GetExportedTypes()
            .Where(t => t.GetCustomAttribute<CommandAttribute>() is {Type: CommandType.POST});

        foreach (var postEndpoint in postEndpoints)
        {
            var template = postEndpoint.GetCustomAttribute<CommandAttribute>()!.Route;

            var method = assembly.GetExportedTypes()
                .SingleOrDefault(x => x.Name == nameof(MediatrExtensions))
                ?.GetMethod(nameof(MediatePost))
                ?.MakeGenericMethod(postEndpoint);

            method?.Invoke(assembly, new object?[] { app, template });
        }

        return app;
    }

    private static (string Name, string GroupName) GetNameAndGroupName<T>()
    {
        var splitName = typeof(T).Namespace!.Split('.');

        var (name, groupName) = (splitName[^1], $"{splitName[^3]} Endpoints");

        return (name, groupName);
    }
}

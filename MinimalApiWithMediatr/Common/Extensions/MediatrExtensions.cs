using System.Reflection;
using MediatR;
using MinimalApiWithMediatr.Common.Filters;

namespace MinimalApiWithMediatr.Common.Extensions;

public static class MediatrExtensions
{
    public static WebApplication MediateGet<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        app.MapGet(template, async ([FromServices] IMediator mediatr, [AsParameters] TRequest request) =>
        {
            return await mediatr.Send(request);
        }).AddRouteHandlerFilter<ExceptionsFilter<TRequest>>();

        return app;
    }

    public static WebApplication MediatePost<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        app.MapPost(template, async ([FromServices] IMediator mediatr, [AsParameters] TRequest request) =>
        {
            return  await mediatr.Send(request);
        }).AddRouteHandlerFilter<ExceptionsFilter<TRequest>>();

        return app;
    }

    public static WebApplication MapRoutesFromAssembly(this WebApplication app, Assembly assembly)
    {
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
}

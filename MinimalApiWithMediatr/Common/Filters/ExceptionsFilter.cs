using ValidationException = MinimalApiWithMediatr.Common.Exceptions.ValidationException;

namespace MinimalApiWithMediatr.Common.Filters;

public class ExceptionsFilter<T> : IRouteHandlerFilter where T : IHttpRequest
{
    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (ValidationException ex)
        {
            return Results.BadRequest(new {succeeded = false, errors = ex.Errors});
        }

    }
}
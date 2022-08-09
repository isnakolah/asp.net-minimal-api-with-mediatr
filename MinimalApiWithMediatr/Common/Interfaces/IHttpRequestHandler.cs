using MediatR;

namespace MinimalApiWithMediatr.Common.Interfaces;

public interface IHttpRequestHandler<in TRequest> : IRequestHandler<TRequest, IResult>
    where TRequest : IHttpRequest
{
}
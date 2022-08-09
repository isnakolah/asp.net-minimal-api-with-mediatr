using MediatR;

namespace MinimalApiWithMediatr.Common.Interfaces;

public interface IHttpRequest : IRequest<IResult>
{
}
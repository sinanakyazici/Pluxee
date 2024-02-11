using MediatR;

namespace Pluxee.Domain.Cqrs;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

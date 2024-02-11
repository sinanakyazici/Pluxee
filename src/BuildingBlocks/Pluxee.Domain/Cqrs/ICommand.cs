using MediatR;

namespace Pluxee.Domain.Cqrs;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
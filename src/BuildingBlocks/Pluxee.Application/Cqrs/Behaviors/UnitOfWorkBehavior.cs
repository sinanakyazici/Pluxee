using MediatR;
using Pluxee.Domain;
using Pluxee.Domain.Cqrs;

namespace Pluxee.Application.Cqrs.Behaviors;

public class UnitOfWorkBehavior<TRequest>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, Unit>
    where TRequest : ICommand
{
    public async Task<Unit> Handle(TRequest request, RequestHandlerDelegate<Unit> next, CancellationToken cancellationToken)
    {
        await next();
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}


public class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return response!;
    }
}
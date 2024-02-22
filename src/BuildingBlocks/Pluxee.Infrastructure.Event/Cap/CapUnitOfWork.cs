using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore.Storage;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.Infrastructure.Event.Cap;

public class CapUnitOfWork(BaseDbContext baseDbContext, ICapPublisher capPublisher) : EfUnitOfWork(baseDbContext), ICapUnitOfWork
{
    private readonly BaseDbContext _baseDbContext = baseDbContext;

    public IDbContextTransaction BeginTransaction(bool autoCommit = false)
    {
        if (CurrentTransaction != null) throw new InvalidOperationException($"Transaction {CurrentTransaction.TransactionId} is already active.");
        CurrentTransaction = _baseDbContext.Database.BeginTransaction(capPublisher, autoCommit);
        return CurrentTransaction;
    }

    public async Task PublishAsync<T>(string name, T? contentObj, string? callbackName = null, CancellationToken cancellationToken = default)
    {
        await capPublisher.PublishAsync(name, contentObj, callbackName, cancellationToken);
    }
}
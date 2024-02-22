using Microsoft.EntityFrameworkCore.Storage;
using Pluxee.Domain;

namespace Pluxee.Infrastructure.Data.EfCore;

public class EfUnitOfWork(BaseDbContext baseDbContext) : IUnitOfWork
{
    public bool HasActiveTransaction => baseDbContext.HasActiveTransaction;

    public IDbContextTransaction? CurrentTransaction
    {
        get => baseDbContext.CurrentTransaction;
        set => baseDbContext.CurrentTransaction = value;
    }

    public int SaveChanges()
    {
        return baseDbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await baseDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return await baseDbContext.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        await baseDbContext.CommitTransactionAsync(cancellationToken);
    }

}
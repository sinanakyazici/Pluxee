using Microsoft.EntityFrameworkCore.Storage;

namespace Pluxee.Domain;

public interface IUnitOfWork
{
    public bool HasActiveTransaction { get; }
    public IDbContextTransaction? CurrentTransaction { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
}
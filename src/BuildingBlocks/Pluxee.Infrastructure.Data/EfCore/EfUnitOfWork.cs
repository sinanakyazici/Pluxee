using Pluxee.Domain;

namespace Pluxee.Infrastructure.Data.EfCore;

public class EfUnitOfWork(BaseDbContext baseDbContext) : IUnitOfWork
{
    public int SaveChanges()
    {
        return baseDbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await baseDbContext.SaveChangesAsync(cancellationToken);
    }
}
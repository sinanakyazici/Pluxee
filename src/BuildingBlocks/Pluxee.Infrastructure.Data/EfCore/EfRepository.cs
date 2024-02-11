using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pluxee.Domain;

namespace Pluxee.Infrastructure.Data.EfCore;

public abstract class EfRepository<TEntity>(BaseDbContext dbContext) : ICommandRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();


    public virtual EntityEntry<TEntity> Add(TEntity obj)
    {
        return _dbSet.Add(obj);
    }

    public virtual void AddRange(params TEntity[] entities)
    {
        _dbSet.AddRange(entities);
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }

    public virtual ValueTask<EntityEntry<TEntity>> AddAsync(TEntity obj, CancellationToken cancellationToken)
    {
        return _dbSet.AddAsync(obj, cancellationToken);
    }

    public virtual Task AddRangeAsync(params TEntity[] entities)
    {
        return _dbSet.AddRangeAsync(entities);
    }

    public virtual Task AddRangeAsync(IEnumerable<TEntity> obj)
    {
        return _dbSet.AddRangeAsync(obj);
    }

    public virtual EntityEntry<TEntity> Update(TEntity obj)
    {
        return _dbSet.Update(obj);
    }

    public virtual void Update(params TEntity[] entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual void Update(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual EntityEntry<TEntity> Remove(TEntity obj)
    {
        return dbContext.Remove(obj);
    }

    public virtual void RemoveRange(params TEntity[] entities)
    {
        dbContext.RemoveRange(entities.AsEnumerable() ?? throw new InvalidOperationException());
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        dbContext.RemoveRange(entities);
    }

    protected IQueryable<TEntity> Query()
    {
        return _dbSet.AsQueryable();
    }

    protected async Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken)
    {
        return await dbContext.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
    }

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
﻿using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Pluxee.Domain;

public interface ICommandRepository<TEntity> : IDisposable where TEntity : class
{
    EntityEntry<TEntity> Add(TEntity obj);
    void AddRange(params TEntity[] entities);
    void AddRange(IEnumerable<TEntity> entities);
    ValueTask<EntityEntry<TEntity>> AddAsync(TEntity obj, CancellationToken cancellationToken);
    Task AddRangeAsync(params TEntity[] entities);
    Task AddRangeAsync(IEnumerable<TEntity> obj);
    EntityEntry<TEntity> Update(TEntity obj);
    void Update(params TEntity[] entities);
    void Update(IEnumerable<TEntity> entities);
    EntityEntry<TEntity> Remove(TEntity obj);
    void RemoveRange(params TEntity[] entities);
    void RemoveRange(IEnumerable<TEntity> entities);
}
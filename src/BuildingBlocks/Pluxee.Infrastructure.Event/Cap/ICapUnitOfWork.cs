using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore.Storage;
using Pluxee.Domain;

namespace Pluxee.Infrastructure.Event.Cap;

public interface ICapUnitOfWork : IUnitOfWork
{
    IDbContextTransaction BeginTransaction(bool autoCommit = false);
    Task PublishAsync<T>(string name, T? contentObj, string? callbackName = null, CancellationToken cancellationToken = default);
}
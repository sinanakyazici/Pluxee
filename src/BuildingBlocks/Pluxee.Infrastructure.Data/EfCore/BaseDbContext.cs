using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Pluxee.Infrastructure.Data.EfCore;

public abstract class BaseDbContext(IConfiguration configuration, ILoggerFactory loggerFactory) : DbContext
{
    private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Command");
        optionsBuilder.UseLoggerFactory(loggerFactory).EnableSensitiveDataLogging().UseNpgsql(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    public bool HasActiveTransaction => CurrentTransaction != null;

    public IDbContextTransaction? CurrentTransaction { get; set; }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        if (CurrentTransaction != null) throw new InvalidOperationException($"Transaction {CurrentTransaction.TransactionId} is already active.");
        CurrentTransaction = await Database.BeginTransactionAsync(cancellationToken);
        return CurrentTransaction;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        if (!HasActiveTransaction) throw new ArgumentNullException(nameof(CurrentTransaction));

        try
        {
            await CurrentTransaction!.CommitAsync(cancellationToken);
        }
        finally
        {
            CurrentTransaction?.Dispose();
            CurrentTransaction = null;
        }
    }
}
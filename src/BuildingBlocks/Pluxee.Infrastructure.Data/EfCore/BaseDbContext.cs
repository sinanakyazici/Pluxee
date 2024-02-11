using Microsoft.EntityFrameworkCore;
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
}
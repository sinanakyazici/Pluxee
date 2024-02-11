using Microsoft.EntityFrameworkCore;
using Pluxee.CustomerService.Infrastructure.EntityTypeConfigurations;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.CustomerService.Infrastructure.Data;

public class CustomerContext(IConfiguration configuration, ILoggerFactory loggerFactory) : BaseDbContext(configuration, loggerFactory)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
    }
}
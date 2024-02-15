using Microsoft.EntityFrameworkCore;
using Pluxee.Infrastructure.Data.EfCore;
using Pluxee.OrderService.Infrastructure.Data.EntityTypeConfigurations;

namespace Pluxee.OrderService.Infrastructure.Data;

public class OrderContext(IConfiguration configuration, ILoggerFactory loggerFactory) : BaseDbContext(configuration, loggerFactory)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
    }
}
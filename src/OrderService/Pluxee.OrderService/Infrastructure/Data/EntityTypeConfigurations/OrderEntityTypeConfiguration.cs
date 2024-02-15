using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pluxee.Domain;
using Pluxee.OrderService.Domain.Order;

namespace Pluxee.OrderService.Infrastructure.Data.EntityTypeConfigurations;


public class OrderEntityTypeConfiguration : EntityTypeConfiguration<Order, Guid>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");

        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.TotalPrice).HasColumnName("total_price");
        builder.Property(x => x.Notes).HasColumnName("notes");

        base.Configure(builder);
    }
}
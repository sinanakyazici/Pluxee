using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain;

namespace Pluxee.CustomerService.Infrastructure.EntityTypeConfigurations;


public class CustomerEntityTypeConfiguration : EntityTypeConfiguration<Customer, Guid>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customer");

        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.FirstName).HasColumnName("first_name");
        builder.Property(x => x.LastName).HasColumnName("last_name");

        base.Configure(builder);
    }
}
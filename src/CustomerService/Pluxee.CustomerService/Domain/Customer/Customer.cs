using Pluxee.Domain;

namespace Pluxee.CustomerService.Domain.Customer;

public class Customer : Entity<Guid>
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
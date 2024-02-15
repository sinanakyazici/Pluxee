using Pluxee.Domain.Cqrs;

namespace Pluxee.CustomerService.Application.Commands.CreateCustomer;

public class CreateCustomerCommand : ICommand
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
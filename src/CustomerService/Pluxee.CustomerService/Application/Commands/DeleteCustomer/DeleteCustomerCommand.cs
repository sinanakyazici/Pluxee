using Pluxee.Domain.Cqrs;

namespace Pluxee.CustomerService.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommand : ICommand
{
    public Guid Id { get; set; }
}
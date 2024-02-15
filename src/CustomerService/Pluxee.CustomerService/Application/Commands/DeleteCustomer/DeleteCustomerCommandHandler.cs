using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;

namespace Pluxee.CustomerService.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository) : ICommandHandler<DeleteCustomerCommand>
{
    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerCommandRepository.GetCustomer(request.Id);
        if (customer != null)
        {
            customerCommandRepository.Remove(customer);
        }
    }
}
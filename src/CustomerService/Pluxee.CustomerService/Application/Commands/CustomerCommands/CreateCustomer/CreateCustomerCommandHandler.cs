using AutoMapper;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;

namespace Pluxee.CustomerService.Application.Commands.CustomerCommands.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, IMapper mapper) : ICommandHandler<CreateCustomerCommand>
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Customer>(request);
        await customerCommandRepository.AddAsync(customer, cancellationToken);
    }
}
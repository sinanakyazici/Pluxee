using AutoMapper;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;
using Pluxee.Infrastructure.Event.Cap;
using Pluxee.Shared.Domain.Customer.Events;
using Pluxee.Shared.Domain.Order.Events;

namespace Pluxee.CustomerService.Application.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, IMapper mapper, ICapUnitOfWork capUnitOfWork)
    : ICommandHandler<CreateCustomerCommand>
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = capUnitOfWork.BeginTransaction(autoCommit: false);
        var customer = mapper.Map<Customer>(request);
        customer.Id = Guid.NewGuid();
        await customerCommandRepository.AddAsync(customer, cancellationToken);
        await capUnitOfWork.SaveChangesAsync(cancellationToken);

        var customerCreatedIntegrationEvent = new CustomerCreatedIntegrationEvent { CustomerId = customer.Id };
        await capUnitOfWork.PublishAsync(typeof(CustomerCreatedIntegrationEvent).FullName!, customerCreatedIntegrationEvent, callbackName: typeof(OrderCreatedStatusIntegrationEvent).FullName!, cancellationToken: cancellationToken);
        await capUnitOfWork.CommitTransactionAsync(cancellationToken);
    }
}
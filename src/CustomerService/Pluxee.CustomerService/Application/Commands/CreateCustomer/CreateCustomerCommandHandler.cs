using AutoMapper;
using DotNetCore.CAP;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;
using Pluxee.Infrastructure.Data.EfCore;
using Pluxee.Shared.Domain.Customer.Events;
using Pluxee.Shared.Domain.Order.Events;

namespace Pluxee.CustomerService.Application.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, IMapper mapper, BaseDbContext customerContext, ICapPublisher capPublisher)
    : ICommandHandler<CreateCustomerCommand>
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await using var trans = customerContext.Database.BeginTransaction(capPublisher, autoCommit: false);
        var customer = mapper.Map<Customer>(request);
        customer.Id = Guid.NewGuid();
        await customerCommandRepository.AddAsync(customer, cancellationToken);
        var customerCreatedIntegrationEvent = new CustomerCreatedIntegrationEvent { CustomerId = customer.Id };
        await capPublisher.PublishDelayAsync(TimeSpan.FromSeconds(10), typeof(CustomerCreatedIntegrationEvent).FullName!, customerCreatedIntegrationEvent, callbackName: typeof(OrderCreatedStatusIntegrationEvent).FullName!, cancellationToken: cancellationToken);
        await customerContext.SaveChangesAsync(cancellationToken);
        await trans.CommitAsync(cancellationToken);
    }
}
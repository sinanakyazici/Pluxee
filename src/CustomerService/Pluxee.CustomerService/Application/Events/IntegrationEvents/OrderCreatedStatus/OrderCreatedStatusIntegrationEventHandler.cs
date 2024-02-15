using DotNetCore.CAP;
using MediatR;
using Pluxee.CustomerService.Application.Commands.DeleteCustomer;
using Pluxee.Domain.Event.Integration;
using Pluxee.Infrastructure.Event.Cap;
using Pluxee.Shared.Domain.Order.Events;

namespace Pluxee.CustomerService.Application.Events.IntegrationEvents.OrderCreatedStatus;

public class OrderCreatedStatusIntegrationEventHandler(IMediator mediator) : IIntegrationEventHandler<OrderCreatedStatusIntegrationEvent>, ICapSubscribe
{
    [EasyCapSubscribe<OrderCreatedStatusIntegrationEvent>]
    public async Task<object> Handle(OrderCreatedStatusIntegrationEvent @event)
    {
        if (!@event.IsSuccess)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand { Id = @event.CustomerId };
            await mediator.Send(deleteCustomerCommand);
        }

        return new { };
    }
}
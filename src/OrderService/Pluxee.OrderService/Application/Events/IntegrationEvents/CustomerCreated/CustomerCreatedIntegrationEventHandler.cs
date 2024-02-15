using DotNetCore.CAP;
using MediatR;
using Pluxee.Domain.Event.Integration;
using Pluxee.Infrastructure.Event.Cap;
using Pluxee.OrderService.Application.Commands.CreateOrder;
using Pluxee.Shared.Domain.Customer.Events;

namespace Pluxee.OrderService.Application.Events.IntegrationEvents.CustomerCreated;

public class CustomerCreatedIntegrationEventHandler(IMediator mediator) : IIntegrationEventHandler<CustomerCreatedIntegrationEvent>, ICapSubscribe
{
    [EasyCapSubscribe<CustomerCreatedIntegrationEvent>]
    public async Task<object> Handle(CustomerCreatedIntegrationEvent @event)
    {
        var createOrderCommand = new CreateOrderCommand { Id = Guid.NewGuid(), Status = 1, TotalPrice = 100, Notes = $"created by {@event.CustomerId} customer" };
        try
        {
            await mediator.Send(createOrderCommand);
            return new { @event.CustomerId, OrderId = createOrderCommand.Id, IsSuccess = true };

        }
        catch (Exception e)
        {
            return new { @event.CustomerId, IsSuccess = false };
        }
    }
}
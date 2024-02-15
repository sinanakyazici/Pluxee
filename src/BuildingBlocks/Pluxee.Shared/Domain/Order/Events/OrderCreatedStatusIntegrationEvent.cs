using Pluxee.Domain.Event.Integration;

namespace Pluxee.Shared.Domain.Order.Events;

public class OrderCreatedStatusIntegrationEvent : IntegrationEvent
{
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
    public bool IsSuccess { get; set; }
}
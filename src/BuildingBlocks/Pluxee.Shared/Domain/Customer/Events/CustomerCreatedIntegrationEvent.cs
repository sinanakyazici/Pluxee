using Pluxee.Domain.Event.Integration;

namespace Pluxee.Shared.Domain.Customer.Events;

public class CustomerCreatedIntegrationEvent : IntegrationEvent
{
    public Guid CustomerId { get; set; }
}
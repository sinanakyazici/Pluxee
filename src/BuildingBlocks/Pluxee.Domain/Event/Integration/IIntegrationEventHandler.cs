namespace Pluxee.Domain.Event.Integration;

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    Task<object> Handle(TIntegrationEvent @event);
}

public interface IIntegrationEventHandler
{
}
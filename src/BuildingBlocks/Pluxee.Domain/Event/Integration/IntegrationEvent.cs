namespace Pluxee.Domain.Event.Integration;

public class IntegrationEvent(Guid id, DateTime createTime)
{
    public IntegrationEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
    {
    }

    public Guid Id { get; private init; } = id;

    public DateTime CreationTime { get; private init; } = createTime;
}
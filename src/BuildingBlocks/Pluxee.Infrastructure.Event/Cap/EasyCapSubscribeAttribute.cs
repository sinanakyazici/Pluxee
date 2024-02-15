using DotNetCore.CAP;

namespace Pluxee.Infrastructure.Event.Cap;

public class EasyCapSubscribeAttribute<T> : CapSubscribeAttribute
{
    public EasyCapSubscribeAttribute() : base(typeof(T).FullName!)
    {
        Group = typeof(T).FullName!;
    }
}
using Autofac;
using Pluxee.Infrastructure.Event.Cap;

namespace Pluxee.Infrastructure.Event;

public class EventModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CapUnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}
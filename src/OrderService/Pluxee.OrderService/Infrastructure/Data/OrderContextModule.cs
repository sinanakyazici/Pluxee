using Autofac;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.OrderService.Infrastructure.Data;

public class OrderContextModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OrderContext>().As<BaseDbContext>().InstancePerLifetimeScope();
    }
}
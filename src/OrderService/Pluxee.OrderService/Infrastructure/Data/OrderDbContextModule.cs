using Autofac;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.OrderService.Infrastructure.Data;

public class OrderDbContextModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OrderDbContext>().AsSelf().As<BaseDbContext>().InstancePerLifetimeScope();
    }
}
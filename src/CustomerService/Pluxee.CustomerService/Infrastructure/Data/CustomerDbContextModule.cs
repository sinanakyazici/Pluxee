using Autofac;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.CustomerService.Infrastructure.Data;

public class CustomerDbContextModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerDbContext>().AsSelf().As<BaseDbContext>().InstancePerLifetimeScope();
    }
}
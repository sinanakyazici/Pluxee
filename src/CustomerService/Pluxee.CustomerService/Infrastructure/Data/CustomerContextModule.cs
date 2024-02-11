using Autofac;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.CustomerService.Infrastructure.Data;

public class CustomerContextModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerContext>().As<BaseDbContext>().InstancePerLifetimeScope();
    }
}
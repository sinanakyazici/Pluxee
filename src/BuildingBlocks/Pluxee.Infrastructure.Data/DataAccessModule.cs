using Autofac;
using Pluxee.Domain;
using Pluxee.Infrastructure.Data.EfCore;
using System.Reflection;

namespace Pluxee.Infrastructure.Data;

public class DataAccessModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var entryAssembly = Assembly.GetEntryAssembly()!;

        builder.RegisterType<EfUnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(entryAssembly).AssignableTo<IQueryRepository>().AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(entryAssembly).AsClosedTypesOf(typeof(ICommandRepository<>));
    }
}
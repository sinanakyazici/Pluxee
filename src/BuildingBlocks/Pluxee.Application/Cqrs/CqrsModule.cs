using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Pluxee.Application.Cqrs.Behaviors;
using System.Reflection;

namespace Pluxee.Application.Cqrs;

public class CqrsModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var entryAssembly = Assembly.GetEntryAssembly()!;
        var configuration = MediatRConfigurationBuilder.Create(entryAssembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .WithCustomPipelineBehavior(typeof(UnitOfWorkBehavior<>))
            .WithCustomPipelineBehavior(typeof(UnitOfWorkBehavior<,>))
            .Build();

        builder.RegisterMediatR(configuration);
    }
}
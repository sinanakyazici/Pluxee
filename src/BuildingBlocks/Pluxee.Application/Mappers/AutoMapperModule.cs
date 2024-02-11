using Autofac;
using AutoMapper;
using System.Reflection;

namespace Pluxee.Application.Mappers;

public class AutoMapperModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var entryAssembly = Assembly.GetEntryAssembly()!;
        var mapper = new MapperConfiguration(config => config.AddMaps(entryAssembly));
        builder.RegisterInstance(mapper.CreateMapper());
    }
}
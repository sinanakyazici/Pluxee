using Autofac;
using Autofac.Extensions.DependencyInjection;
using Pluxee.Application.Cqrs;
using Pluxee.Application.Mappers;
using Pluxee.CustomerService.Infrastructure.Data;
using Pluxee.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutoMapperModule());
    containerBuilder.RegisterModule(new DataAccessModule());
    containerBuilder.RegisterModule(new CqrsModule());
    containerBuilder.RegisterModule(new CustomerContextModule());
});

var app = builder.Build();

//Configure Context
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Pluxee.Application.Cqrs;
using Pluxee.Application.Mappers;
using Pluxee.Infrastructure.Data;
using Pluxee.Infrastructure.Event;
using Pluxee.OrderService.Application.Events.IntegrationEvents.CustomerCreated;
using Pluxee.OrderService.Infrastructure.Data;
using Savorboard.CAP.InMemoryMessageQueue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var rabbitMqConfig = builder.Configuration.GetSection(nameof(RabbitMqConfig)).Get<RabbitMqConfig>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CustomerCreatedIntegrationEventHandler>();

builder.Services.AddCap(options =>
{
    // options.UseInMemoryStorage();

    options.UseEntityFramework<OrderDbContext>();

    if (rabbitMqConfig != null)
    {
        options.UseRabbitMQ(conf =>
        {
            conf.HostName = rabbitMqConfig.Hostname;
            conf.UserName = rabbitMqConfig.Username;
            conf.Password = rabbitMqConfig.Password;
            conf.Port = rabbitMqConfig.Port;
            conf.VirtualHost = rabbitMqConfig.VirtualHost;

            // conf.ExchangeName = rabbitMqConfig.ExchangeName;
        });
    }
    else
    {
        options.UseInMemoryMessageQueue();
    }
    options.UseDashboard(path => path.PathMatch = "/cap");
});

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
    containerBuilder.RegisterModule(new EventModule());
    containerBuilder.RegisterModule(new OrderDbContextModule());
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

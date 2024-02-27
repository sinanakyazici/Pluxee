using System.Transactions;
using AutoMapper;
using Dapper;
using Npgsql;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;
using Pluxee.Infrastructure.Event.Cap;
using Pluxee.Shared.Domain.Customer.Events;
using Pluxee.Shared.Domain.Order.Events;
using IsolationLevel = System.Data.IsolationLevel;

namespace Pluxee.CustomerService.Application.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, IMapper mapper, ICapUnitOfWork capUnitOfWork, IConfiguration configuration)
    : ICommandHandler<CreateCustomerCommand>
{
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        //await using var transaction = capUnitOfWork.BeginTransaction(autoCommit: false);
        //var customer = mapper.Map<Customer>(request);
        //customer.Id = Guid.NewGuid();
        //await customerCommandRepository.AddAsync(customer, cancellationToken);
        //await capUnitOfWork.SaveChangesAsync(cancellationToken);

        //var customerCreatedIntegrationEvent = new CustomerCreatedIntegrationEvent { CustomerId = customer.Id };
        //await capUnitOfWork.PublishAsync(typeof(CustomerCreatedIntegrationEvent).FullName!, customerCreatedIntegrationEvent, callbackName: typeof(OrderCreatedStatusIntegrationEvent).FullName!, cancellationToken: cancellationToken);
        //await capUnitOfWork.CommitTransactionAsync(cancellationToken);

        // 1. We will create a connection
        var ConnectionString = configuration.GetConnectionString("Query");
        
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync(cancellationToken);
        var transaction = await connection.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            // 2. We will create an `INSERT` sql statement
            var sql = "INSERT INTO \"customer\" (id, email, first_name, last_name) VALUES ('78000985-c789-439a-9714-821f36c9c051', 'sinan_akyazici@hotmailx.com', 'Sinan', 'AKYAZICI');";
            // 3. Call the `Execute` method
            var rowsAffected = await connection.ExecuteAsync(sql);
            throw new Exception("test");
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);

            var sql = "INSERT INTO \"customer2\" (id, email, first_name, last_name) VALUES ('78000985-c789-439a-9714-821f36c9c051', 'sinan_akyazici@hotmaily.com', 'Sinan', 'AKYAZICI');";
            // 3. Call the `Execute` method
            var rowsAffected = await connection.ExecuteAsync(sql);
            throw new Exception("testx");
        }
    }
}
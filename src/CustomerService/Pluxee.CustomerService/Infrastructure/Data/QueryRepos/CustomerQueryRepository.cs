using Dapper;
using Npgsql;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Infrastructure.Data.Dapper;

namespace Pluxee.CustomerService.Infrastructure.Data.QueryRepos;

public class CustomerQueryRepository(IConfiguration configuration) : DapperRepository(configuration), ICustomerQueryRepository
{
    public async Task<IEnumerable<CustomerViewModel>> GetCustomersAsync(CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync(cancellationToken);
        var parameters = new DynamicParameters();

        var sql = "select * from customer";
        var customerViewModels = await connection.QueryAsync<CustomerViewModel>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
        return customerViewModels;
    }
}
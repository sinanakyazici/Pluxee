using Dapper;
using Npgsql;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Infrastructure.Data.Dapper;

namespace Pluxee.CustomerService.Infrastructure.QueryRepos;

public class CustomerQueryRepository(IConfiguration configuration) : DapperRepository(configuration), ICustomerQueryRepository
{
    public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();
        var parameters = new DynamicParameters();

        var sql = "select * from customer";
        var customerViewModels = await connection.QueryAsync<CustomerViewModel>(sql, parameters);
        return customerViewModels;
    }
}
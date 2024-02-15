using Dapper;
using Npgsql;
using Pluxee.Infrastructure.Data.Dapper;
using Pluxee.OrderService.Domain.Order;

namespace Pluxee.OrderService.Infrastructure.Data.QueryRepos;

public class OrderQueryRepository(IConfiguration configuration) : DapperRepository(configuration), IOrderQueryRepository
{
    public async Task<IEnumerable<OrderViewModel>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync(cancellationToken);
        var parameters = new DynamicParameters();

        var sql = "select * from \"order\"";
        var orderViewModels = await connection.QueryAsync<OrderViewModel>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
        return orderViewModels;
    }
}
using Dapper;
using Microsoft.Extensions.Configuration;
using Pluxee.Domain;

namespace Pluxee.Infrastructure.Data.Dapper;

public abstract class DapperRepository : IQueryRepository
{
    protected string? ConnectionString;

    protected DapperRepository(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("Query");
        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }
}
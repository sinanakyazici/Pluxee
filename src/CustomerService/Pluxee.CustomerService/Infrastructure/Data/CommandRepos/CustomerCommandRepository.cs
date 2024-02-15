using Microsoft.EntityFrameworkCore;
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.CustomerService.Infrastructure.Data.CommandRepos;

public class CustomerCommandRepository(BaseDbContext dbContext) : EfRepository<Customer>(dbContext), ICustomerCommandRepository
{
    public async Task<Customer?> GetCustomer(Guid customerId)
    {
        return await Query().SingleOrDefaultAsync(x => x.Id == customerId);
    }
}
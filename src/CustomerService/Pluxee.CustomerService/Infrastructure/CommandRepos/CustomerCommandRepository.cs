using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Infrastructure.Data.EfCore;

namespace Pluxee.CustomerService.Infrastructure.CommandRepos;

public class CustomerCommandRepository(BaseDbContext dbContext) : EfRepository<Customer>(dbContext), ICustomerCommandRepository;
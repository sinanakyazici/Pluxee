using Pluxee.Domain;

namespace Pluxee.CustomerService.Domain.Customer;

public interface ICustomerQueryRepository : IQueryRepository
{
    Task<IEnumerable<CustomerViewModel>> GetCustomersAsync(CancellationToken cancellationToken);
}
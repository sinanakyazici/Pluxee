using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;

namespace Pluxee.CustomerService.Application.Queries.CustomerQueries.GetCustomers;

public class GetCustomersQuery : IQuery<IEnumerable<CustomerViewModel>>
{
}
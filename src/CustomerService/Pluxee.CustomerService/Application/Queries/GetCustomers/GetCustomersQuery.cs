using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;

namespace Pluxee.CustomerService.Application.Queries.GetCustomers;

public class GetCustomersQuery : IQuery<IEnumerable<CustomerViewModel>>
{
}
using Pluxee.CustomerService.Domain.Customer;
using Pluxee.Domain.Cqrs;

namespace Pluxee.CustomerService.Application.Queries.CustomerQueries.GetCustomers;


public class GetCustomersQueryHandler(ICustomerQueryRepository customerQueryRepository) : IQueryHandler<GetCustomersQuery, IEnumerable<CustomerViewModel>>
{
    public async Task<IEnumerable<CustomerViewModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await customerQueryRepository.GetCustomersAsync(cancellationToken);
    }
}
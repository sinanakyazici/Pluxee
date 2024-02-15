using Pluxee.Domain;

namespace Pluxee.CustomerService.Domain.Customer;

public interface ICustomerCommandRepository : ICommandRepository<Customer>
{
    Task<Customer?> GetCustomer(Guid customerId);
}
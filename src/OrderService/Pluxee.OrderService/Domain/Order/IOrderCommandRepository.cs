using Pluxee.Domain;

namespace Pluxee.OrderService.Domain.Order;

public interface IOrderCommandRepository : ICommandRepository<Order>
{
}
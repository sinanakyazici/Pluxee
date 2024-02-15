using Pluxee.Domain.Cqrs;
using Pluxee.OrderService.Domain.Order;

namespace Pluxee.OrderService.Application.Queries.GetOrders;

public class GetOrdersQuery : IQuery<IEnumerable<OrderViewModel>>
{
}
using Pluxee.Domain;

namespace Pluxee.OrderService.Domain.Order;

public interface IOrderQueryRepository : IQueryRepository
{
    Task<IEnumerable<OrderViewModel>> GetOrdersAsync(CancellationToken cancellationToken);
}
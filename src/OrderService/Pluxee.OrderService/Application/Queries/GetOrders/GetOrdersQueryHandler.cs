using Pluxee.Domain.Cqrs;
using Pluxee.OrderService.Domain.Order;

namespace Pluxee.OrderService.Application.Queries.GetOrders;


public class GetOrdersQueryHandler(IOrderQueryRepository orderQueryRepository) : IQueryHandler<GetOrdersQuery, IEnumerable<OrderViewModel>>
{
    public async Task<IEnumerable<OrderViewModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await orderQueryRepository.GetOrdersAsync(cancellationToken);
    }
}
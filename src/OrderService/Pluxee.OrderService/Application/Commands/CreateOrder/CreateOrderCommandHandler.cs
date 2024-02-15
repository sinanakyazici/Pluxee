using AutoMapper;
using Pluxee.Domain.Cqrs;
using Pluxee.OrderService.Domain.Order;

namespace Pluxee.OrderService.Application.Commands.CreateOrder;

public class CreateOrderCommandHandler(IOrderCommandRepository orderCommandRepository, IMapper mapper)
    : ICommandHandler<CreateOrderCommand>
{
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = mapper.Map<Order>(request);
        order.Id = Guid.NewGuid();
        await orderCommandRepository.AddAsync(order, cancellationToken);
        throw new Exception("test");
    }
}
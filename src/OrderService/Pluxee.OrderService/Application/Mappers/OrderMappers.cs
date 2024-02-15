using AutoMapper;
using Pluxee.OrderService.Application.Commands.CreateOrder;
using Pluxee.OrderService.Domain.Order;

namespace Pluxee.OrderService.Application.Mappers;

public class OrderMappers : Profile
{
    public OrderMappers()
    {
        CreateMap<CreateOrderCommand, Order>();
    }
}
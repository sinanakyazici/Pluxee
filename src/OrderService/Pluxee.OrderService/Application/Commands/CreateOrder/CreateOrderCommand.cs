using Pluxee.Domain.Cqrs;

namespace Pluxee.OrderService.Application.Commands.CreateOrder;

public class CreateOrderCommand : ICommand
{
    public Guid Id { get; set; }
    public int Status { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Notes { get; set; }
}
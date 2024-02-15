using Pluxee.Domain;

namespace Pluxee.OrderService.Domain.Order;

public class Order : Entity<Guid>
{
    public int Status { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Notes { get; set; }
}
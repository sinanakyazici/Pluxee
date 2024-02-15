namespace Pluxee.OrderService.Domain.Order;

public class OrderViewModel
{
    public Guid Id { get; set; }
    public int Status { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Notes { get; set; }
}
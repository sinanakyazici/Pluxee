namespace Pluxee.CustomerService.Domain.Customer;

public class CustomerViewModel
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
}
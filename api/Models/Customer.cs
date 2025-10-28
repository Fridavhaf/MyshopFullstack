namespace Myshop.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    // navigation property
    public virtual List<Order>? Orders { get; set; }
}
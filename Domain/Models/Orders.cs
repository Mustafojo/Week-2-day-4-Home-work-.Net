namespace Domain.Models;
public class Orders
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime Data { get; set; }
    public decimal Amount { get; set; }
}
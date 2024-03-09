using System.Data.Common;

public class OrderProduct
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public string ProductName { get; set; }
}
namespace MyFirstWebAPIProject.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
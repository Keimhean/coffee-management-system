namespace KeimheanCafePOS.Domain.DesignPatterns.Prototype;

/// <summary>
/// Cloneable order prototype
/// Used to duplicate existing orders (e.g., "Same as Table 5")
/// ចម្លងការបញ្ជាទិញ (Clone order)
/// </summary>
public class OrderPrototype : ICloneable<OrderPrototype>
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<OrderItemPrototype> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderType { get; set; } = string.Empty; // DineIn, TakeOut, Delivery
    public string Status { get; set; } = "Pending";
    public Dictionary<string, string> Metadata { get; set; } = new();

    public OrderPrototype Clone()
    {
        var cloned = new OrderPrototype
        {
            // Don't copy OrderId - it should be assigned new
            CustomerName = this.CustomerName,
            TotalAmount = this.TotalAmount,
            OrderDate = DateTime.UtcNow, // New order gets current time
            OrderType = this.OrderType,
            Status = "Pending", // Reset status
            Metadata = new Dictionary<string, string>(this.Metadata),
            Items = new List<OrderItemPrototype>()
        };

        // Deep copy all items
        foreach (var item in this.Items)
        {
            cloned.Items.Add(item.Clone());
        }

        return cloned;
    }
}

/// <summary>
/// Cloneable order item
/// </summary>
public class OrderItemPrototype : ICloneable<OrderItemPrototype>
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<string> Customizations { get; set; } = new(); // Decorators applied
    public string Notes { get; set; } = string.Empty;

    public OrderItemPrototype Clone()
    {
        return new OrderItemPrototype
        {
            ProductId = this.ProductId,
            ProductName = this.ProductName,
            Price = this.Price,
            Quantity = this.Quantity,
            Customizations = new List<string>(this.Customizations),
            Notes = this.Notes
        };
    }
}

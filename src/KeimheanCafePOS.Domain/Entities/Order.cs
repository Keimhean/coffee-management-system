using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeimheanCafePOS.Domain.Entities;

/// <summary>
/// Represents an order in the system
/// ការបញ្ជាទិញ (Order)
/// </summary>
[Table("orders")]
public class Order
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("OrderNumber")]
    public string OrderNumber { get; set; } = string.Empty;

    [Column("CustomerId")]
    public int? CustomerId { get; set; }

    [Column("TableId")]
    public int? TableId { get; set; }

    [Required]
    [Column("OrderType")]
    public OrderType OrderType { get; set; } = OrderType.DineIn;

    [Required]
    [Column("Status")]
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    [Column("Subtotal")]
    public decimal Subtotal { get; set; }

    [Column("Tax")]
    public decimal Tax { get; set; }

    [Column("Discount")]
    public decimal Discount { get; set; } = 0;

    [Column("DeliveryFee")]
    public decimal DeliveryFee { get; set; } = 0;

    [Column("Total")]
    public decimal Total { get; set; }

    [MaxLength(200)]
    [Column("DeliveryAddress")]
    public string? DeliveryAddress { get; set; }

    [MaxLength(50)]
    [Column("PickupTime")]
    public string? PickupTime { get; set; }

    [MaxLength(500)]
    [Column("Notes")]
    public string? Notes { get; set; }

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("UpdatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [Column("CompletedAt")]
    public DateTime? CompletedAt { get; set; }

    // Navigation properties
    public virtual Customer? Customer { get; set; }
    public virtual Table? Table { get; set; }
    public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public virtual ICollection<PaymentTransaction>? PaymentTransactions { get; set; }
}

public enum OrderType
{
    DineIn = 0,
    TakeOut = 1,
    Delivery = 2
}

public enum OrderStatus
{
    Pending = 0,
    Confirmed = 1,
    Preparing = 2,
    Ready = 3,
    Served = 4,
    Completed = 5,
    Cancelled = 6
}

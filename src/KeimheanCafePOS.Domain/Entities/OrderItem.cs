using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeimheanCafePOS.Domain.Entities;

/// <summary>
/// Represents an item in an order
/// របស់ក្នុងការបញ្ជាទិញ (Order item)
/// </summary>
[Table("order_items")]
public class OrderItem
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("OrderId")]
    public int OrderId { get; set; }

    [Required]
    [Column("ProductId")]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(200)]
    [Column("ProductName")]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [Column("Price")]
    public decimal Price { get; set; }

    [Required]
    [Column("Quantity")]
    public int Quantity { get; set; }

    [Column("Subtotal")]
    public decimal Subtotal => Price * Quantity;

    [MaxLength(500)]
    [Column("Notes")]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
    public virtual ICollection<OrderCustomization>? Customizations { get; set; }
}

/// <summary>
/// Represents customizations applied to an order item (Decorator pattern tracking)
/// ការកែប្រែលើរបស់ម៉ឺនុយ (Order item customizations)
/// </summary>
[Table("order_customizations")]
public class OrderCustomization
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("OrderItemId")]
    public int OrderItemId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("CustomizationName")]
    public string CustomizationName { get; set; } = string.Empty;

    [Required]
    [Column("Price")]
    public decimal Price { get; set; }

    // Navigation property
    public virtual OrderItem? OrderItem { get; set; }
}

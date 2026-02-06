using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeimheanCafePOS.Domain.Entities;

/// <summary>
/// Represents a customer in the system
/// អតិថិជន (Customer)
/// </summary>
[Table("customers")]
public class Customer
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(20)]
    [Column("Phone")]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(100)]
    [Column("Email")]
    public string? Email { get; set; }

    [MaxLength(200)]
    [Column("Address")]
    public string? Address { get; set; }

    [Column("LoyaltyPoints")]
    public int LoyaltyPoints { get; set; } = 0;

    [Column("IsActive")]
    public bool IsActive { get; set; } = true;

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("LastVisitAt")]
    public DateTime? LastVisitAt { get; set; }

    // Navigation properties
    public virtual ICollection<Order>? Orders { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeimheanCafePOS.Domain.Entities;

/// <summary>
/// Represents a table in the restaurant
/// តុក្នុងភោជនីយដ្ឋាន (Restaurant table)
/// </summary>
[Table("tables")]
public class Table
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("TableNumber")]
    public string TableNumber { get; set; } = string.Empty;

    [Required]
    [Column("Capacity")]
    public int Capacity { get; set; }

    [Required]
    [Column("Status")]
    public TableStatus Status { get; set; } = TableStatus.Available;

    [MaxLength(50)]
    [Column("Section")]
    public string Section { get; set; } = "Main"; // Main, Outdoor, VIP, etc.

    [Column("IsActive")]
    public bool IsActive { get; set; } = true;

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("UpdatedAt")]
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public virtual ICollection<Order>? Orders { get; set; }
}

public enum TableStatus
{
    Available = 0,
    Occupied = 1,
    Reserved = 2,
    Cleaning = 3
}

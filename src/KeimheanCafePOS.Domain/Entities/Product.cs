using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeimheanCafePOS.Domain.Entities;

[Table("products")]
public class Product
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("Price")]
    public decimal Price { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("Category")]
    public string Category { get; set; } = string.Empty;

    [Column("CategoryId")]
    public int? CategoryId { get; set; }

    [MaxLength(500)]
    [Column("ImageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    [Column("IsActive")]
    public bool IsActive { get; set; } = true;

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; }

    [Column("UpdatedAt")]
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public virtual MenuCategory? MenuCategory { get; set; }
}

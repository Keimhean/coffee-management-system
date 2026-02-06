using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeimheanCafePOS.Domain.Entities;

/// <summary>
/// Represents a menu category for hierarchical menu structure (Composite pattern)
/// ប្រភេទម៉ឺនុយ (Menu category)
/// </summary>
[Table("menu_categories")]
public class MenuCategory
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("Description")]
    public string? Description { get; set; }

    [Column("ParentCategoryId")]
    public int? ParentCategoryId { get; set; }

    [Column("DisplayOrder")]
    public int DisplayOrder { get; set; } = 0;

    [Column("IsActive")]
    public bool IsActive { get; set; } = true;

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual MenuCategory? ParentCategory { get; set; }
    public virtual ICollection<MenuCategory>? SubCategories { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}

/// <summary>
/// Represents a combo meal (Composite pattern)
/// សំណុំម៉ឺនុយ (Combo meal)
/// </summary>
[Table("combo_meals")]
public class ComboMeal
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("Description")]
    public string? Description { get; set; }

    [Required]
    [Column("ComboPrice")]
    public decimal ComboPrice { get; set; }

    [Column("IsActive")]
    public bool IsActive { get; set; } = true;

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual ICollection<ComboMealItem>? Items { get; set; }
}

/// <summary>
/// Represents items in a combo meal
/// </summary>
[Table("combo_meal_items")]
public class ComboMealItem
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("ComboMealId")]
    public int ComboMealId { get; set; }

    [Required]
    [Column("ProductId")]
    public int ProductId { get; set; }

    [Column("Quantity")]
    public int Quantity { get; set; } = 1;

    // Navigation properties
    public virtual ComboMeal? ComboMeal { get; set; }
    public virtual Product? Product { get; set; }
}

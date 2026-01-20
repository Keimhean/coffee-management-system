namespace KeimheanCafePOS.Domain.DesignPatterns.Prototype;

/// <summary>
/// Cloneable menu item prototype
/// Used to create variations of existing menu items
/// ចម្លងរបស់ម៉ឺនុយ (Clone menu item)
/// </summary>
public class MenuItemPrototype : ICloneable<MenuItemPrototype>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public List<string> AvailableCustomizations { get; set; } = new();
    public Dictionary<string, decimal> CustomizationPrices { get; set; } = new();

    public MenuItemPrototype Clone()
    {
        return new MenuItemPrototype
        {
            // Don't copy Id - it should be assigned new
            Name = this.Name,
            BasePrice = this.BasePrice,
            Category = this.Category,
            Description = this.Description,
            ImageUrl = this.ImageUrl,
            IsActive = this.IsActive,
            AvailableCustomizations = new List<string>(this.AvailableCustomizations),
            CustomizationPrices = new Dictionary<string, decimal>(this.CustomizationPrices)
        };
    }

    /// <summary>
    /// Clone with modifications (useful for creating variations)
    /// </summary>
    public MenuItemPrototype CloneWithName(string newName)
    {
        var cloned = Clone();
        cloned.Name = newName;
        return cloned;
    }

    /// <summary>
    /// Clone with price adjustment (useful for seasonal variations)
    /// </summary>
    public MenuItemPrototype CloneWithPrice(decimal newPrice)
    {
        var cloned = Clone();
        cloned.BasePrice = newPrice;
        return cloned;
    }
}

/// <summary>
/// Cloneable customer profile prototype
/// Used to duplicate customer profiles for regulars or family members
/// ចម្លងព័ត៌មានអតិថិជន (Clone customer profile)
/// </summary>
public class CustomerPrototype : ICloneable<CustomerPrototype>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int LoyaltyPoints { get; set; }
    public List<string> FavoriteItems { get; set; } = new();
    public Dictionary<string, string> Preferences { get; set; } = new();
    public DateTime CreatedAt { get; set; }

    public CustomerPrototype Clone()
    {
        return new CustomerPrototype
        {
            // Don't copy Id - it should be assigned new
            Name = this.Name,
            Phone = "", // Don't copy phone/email as they should be unique
            Email = "",
            Address = this.Address,
            LoyaltyPoints = 0, // New customer starts with 0 points
            FavoriteItems = new List<string>(this.FavoriteItems),
            Preferences = new Dictionary<string, string>(this.Preferences),
            CreatedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Clone for family member with shared preferences
    /// </summary>
    public CustomerPrototype CloneForFamilyMember(string name, string phone, string email)
    {
        var cloned = Clone();
        cloned.Name = name;
        cloned.Phone = phone;
        cloned.Email = email;
        return cloned;
    }
}

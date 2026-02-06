namespace KeimheanCafePOS.Domain.DesignPatterns.Decorator;

/// <summary>
/// Base implementation of a menu item (Concrete Component in Decorator pattern)
/// This represents a basic menu item without any decorations
/// </summary>
public class BaseMenuItem : IMenuItem
{
    private readonly string _name;
    private readonly decimal _basePrice;

    public BaseMenuItem(string name, decimal basePrice)
    {
        _name = name;
        _basePrice = basePrice;
    }

    public string GetDescription() => _name;

    public decimal GetPrice() => _basePrice;

    public string GetBaseName() => _name;
}

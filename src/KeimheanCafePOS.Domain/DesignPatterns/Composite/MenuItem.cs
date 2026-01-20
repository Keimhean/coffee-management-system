namespace KeimheanCafePOS.Domain.DesignPatterns.Composite;

/// <summary>
/// Leaf component representing a single menu item
/// This cannot contain other components
/// របស់ម៉ឺនុយតែមួយ (Single menu item)
/// </summary>
public class MenuItem : IMenuComponent
{
    private readonly string _name;
    private readonly decimal _price;
    private readonly string _description;

    public MenuItem(string name, decimal price, string description = "")
    {
        _name = name;
        _price = price;
        _description = description;
    }

    public string GetName() => _name;

    public decimal GetPrice() => _price;

    public string GetDescription() => _description;

    public List<IMenuComponent> GetItems()
    {
        return new List<IMenuComponent> { this };
    }

    public void Add(IMenuComponent component)
    {
        throw new InvalidOperationException("Cannot add to a leaf menu item");
    }

    public void Remove(IMenuComponent component)
    {
        throw new InvalidOperationException("Cannot remove from a leaf menu item");
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth * 2)}{_name} - ${_price:F2} - {_description}");
    }
}

namespace KeimheanCafePOS.Domain.DesignPatterns.Composite;

/// <summary>
/// Composite component representing a menu category
/// Can contain multiple menu items or sub-categories
/// ប្រភេទម៉ឺនុយ (Menu category)
/// </summary>
public class MenuCategory : IMenuComponent
{
    private readonly string _name;
    private readonly string _description;
    private readonly List<IMenuComponent> _components = new();

    public MenuCategory(string name, string description = "")
    {
        _name = name;
        _description = description;
    }

    public string GetName() => _name;

    public decimal GetPrice()
    {
        return _components.Sum(c => c.GetPrice());
    }

    public string GetDescription() => _description;

    public List<IMenuComponent> GetItems()
    {
        var allItems = new List<IMenuComponent>();
        foreach (var component in _components)
        {
            allItems.AddRange(component.GetItems());
        }
        return allItems;
    }

    public void Add(IMenuComponent component)
    {
        _components.Add(component);
    }

    public void Remove(IMenuComponent component)
    {
        _components.Remove(component);
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth * 2)}[{_name}] - {_description}");
        foreach (var component in _components)
        {
            component.Display(depth + 1);
        }
    }

    public int GetItemCount() => GetItems().Count;
}

/// <summary>
/// Composite component representing a combo meal
/// Combines multiple items at a special price
/// សំណុំម៉ឺនុយ (Combo meal)
/// </summary>
public class ComboMeal : IMenuComponent
{
    private readonly string _name;
    private readonly string _description;
    private readonly decimal _comboPrice;
    private readonly List<IMenuComponent> _components = new();

    public ComboMeal(string name, decimal comboPrice, string description = "")
    {
        _name = name;
        _comboPrice = comboPrice;
        _description = description;
    }

    public string GetName() => $"{_name} (Combo)";

    public decimal GetPrice() => _comboPrice;

    public string GetDescription()
    {
        var items = string.Join(", ", _components.Select(c => c.GetName()));
        return $"{_description} - Includes: {items}";
    }

    public List<IMenuComponent> GetItems()
    {
        return _components;
    }

    public void Add(IMenuComponent component)
    {
        _components.Add(component);
    }

    public void Remove(IMenuComponent component)
    {
        _components.Remove(component);
    }

    public void Display(int depth = 0)
    {
        var regularPrice = _components.Sum(c => c.GetPrice());
        var savings = regularPrice - _comboPrice;
        Console.WriteLine($"{new string('-', depth * 2)}🎁 {_name} - ${_comboPrice:F2} (Save ${savings:F2})");
        Console.WriteLine($"{new string('-', depth * 2)}   {_description}");
        foreach (var component in _components)
        {
            component.Display(depth + 1);
        }
    }

    public decimal GetSavings()
    {
        var regularPrice = _components.Sum(c => c.GetPrice());
        return regularPrice - _comboPrice;
    }
}

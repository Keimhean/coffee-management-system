namespace KeimheanCafePOS.Domain.DesignPatterns.Decorator;

/// <summary>
/// Decorator that adds milk to a menu item
/// ដាក់ទឹកដោះគោបន្ថែម (Add milk)
/// </summary>
public class MilkDecorator : MenuItemDecorator
{
    private const decimal MilkPrice = 0.50m;

    public MilkDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"{_menuItem.GetDescription()} + Milk";

    public override decimal GetPrice() => _menuItem.GetPrice() + MilkPrice;
}

/// <summary>
/// Decorator that adds sugar to a menu item
/// ដាក់ស្ករបន្ថែម (Add sugar)
/// </summary>
public class SugarDecorator : MenuItemDecorator
{
    private const decimal SugarPrice = 0.25m;

    public SugarDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"{_menuItem.GetDescription()} + Sugar";

    public override decimal GetPrice() => _menuItem.GetPrice() + SugarPrice;
}

/// <summary>
/// Decorator that adds whipped cream to a menu item
/// ដាក់ក្រែមវីប (Add whipped cream)
/// </summary>
public class WhippedCreamDecorator : MenuItemDecorator
{
    private const decimal WhippedCreamPrice = 0.75m;

    public WhippedCreamDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"{_menuItem.GetDescription()} + Whipped Cream";

    public override decimal GetPrice() => _menuItem.GetPrice() + WhippedCreamPrice;
}

/// <summary>
/// Decorator that adds an extra shot of espresso
/// ដាក់សុត Espresso បន្ថែម (Add extra espresso shot)
/// </summary>
public class ExtraShotDecorator : MenuItemDecorator
{
    private const decimal ExtraShotPrice = 1.00m;

    public ExtraShotDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"{_menuItem.GetDescription()} + Extra Shot";

    public override decimal GetPrice() => _menuItem.GetPrice() + ExtraShotPrice;
}

/// <summary>
/// Decorator that adds caramel syrup
/// ដាក់ស៊ីរ៉ូ Caramel (Add caramel syrup)
/// </summary>
public class CaramelDecorator : MenuItemDecorator
{
    private const decimal CaramelPrice = 0.60m;

    public CaramelDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"{_menuItem.GetDescription()} + Caramel";

    public override decimal GetPrice() => _menuItem.GetPrice() + CaramelPrice;
}

/// <summary>
/// Decorator that adds vanilla syrup
/// ដាក់ស៊ីរ៉ូ Vanilla (Add vanilla syrup)
/// </summary>
public class VanillaDecorator : MenuItemDecorator
{
    private const decimal VanillaPrice = 0.60m;

    public VanillaDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"{_menuItem.GetDescription()} + Vanilla";

    public override decimal GetPrice() => _menuItem.GetPrice() + VanillaPrice;
}

/// <summary>
/// Decorator that adds chocolate syrup
/// ដាក់ស៊ីរ៉ូសូកូឡា (Add chocolate syrup)
/// </summary>
public class ChocolateDecorator : MenuItemDecorator
{
    private const decimal ChocolatePrice = 0.60m;

    public ChocolateDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"{_menuItem.GetDescription()} + Chocolate";

    public override decimal GetPrice() => _menuItem.GetPrice() + ChocolatePrice;
}

/// <summary>
/// Decorator that makes the drink iced
/// ធ្វើជាភេសជ្ជៈត្រជាក់ (Make it iced)
/// </summary>
public class IceDecorator : MenuItemDecorator
{
    private const decimal IcePrice = 0.30m;

    public IceDecorator(IMenuItem menuItem) : base(menuItem)
    {
    }

    public override string GetDescription() => $"Iced {_menuItem.GetDescription()}";

    public override decimal GetPrice() => _menuItem.GetPrice() + IcePrice;
}

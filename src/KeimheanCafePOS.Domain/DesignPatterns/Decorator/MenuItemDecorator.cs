namespace KeimheanCafePOS.Domain.DesignPatterns.Decorator;

/// <summary>
/// Abstract base class for all menu item decorators
/// This is the Decorator base class in the Decorator pattern
/// </summary>
public abstract class MenuItemDecorator : IMenuItem
{
    protected readonly IMenuItem _menuItem;

    protected MenuItemDecorator(IMenuItem menuItem)
    {
        _menuItem = menuItem;
    }

    public virtual string GetDescription() => _menuItem.GetDescription();

    public virtual decimal GetPrice() => _menuItem.GetPrice();

    public string GetBaseName() => _menuItem.GetBaseName();
}

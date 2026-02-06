namespace KeimheanCafePOS.Domain.DesignPatterns.Decorator;

/// <summary>
/// Interface for menu items that can be decorated with extras/toppings.
/// This is the Component interface in the Decorator pattern.
/// បំណង៖ ប្រើសម្រាប់ធាតុម្ហូបដែលអាចបន្ថែមគ្រឿងបន្ថែមបាន (Purpose: For menu items that can have extras added)
/// </summary>
public interface IMenuItem
{
    /// <summary>
    /// Gets the name/description of the menu item including all decorations
    /// </summary>
    string GetDescription();
    
    /// <summary>
    /// Gets the total price including all decorations
    /// </summary>
    decimal GetPrice();
    
    /// <summary>
    /// Gets the base item without decorations
    /// </summary>
    string GetBaseName();
}

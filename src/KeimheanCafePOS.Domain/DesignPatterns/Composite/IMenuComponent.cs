namespace KeimheanCafePOS.Domain.DesignPatterns.Composite;

/// <summary>
/// Component interface for the Composite pattern
/// Used to create hierarchical menu structures and combo meals
/// រចនាសម្ព័ន្ធម៉ឺនុយជាថ្នាក់ (Hierarchical menu structure)
/// </summary>
public interface IMenuComponent
{
    string GetName();
    decimal GetPrice();
    string GetDescription();
    List<IMenuComponent> GetItems();
    void Add(IMenuComponent component);
    void Remove(IMenuComponent component);
    void Display(int depth = 0);
}

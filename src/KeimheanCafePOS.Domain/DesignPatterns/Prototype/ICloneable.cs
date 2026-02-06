namespace KeimheanCafePOS.Domain.DesignPatterns.Prototype;

/// <summary>
/// Generic interface for objects that can be cloned
/// This is the Prototype interface
/// សម្រាប់ធ្វើការចម្លងវត្ថុ (For cloning objects)
/// </summary>
/// <typeparam name="T">The type of object to clone</typeparam>
public interface ICloneable<T>
{
    /// <summary>
    /// Creates a deep copy of the object
    /// </summary>
    T Clone();
}

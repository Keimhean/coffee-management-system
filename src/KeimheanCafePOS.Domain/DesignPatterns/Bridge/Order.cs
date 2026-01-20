namespace KeimheanCafePOS.Domain.DesignPatterns.Bridge;

/// <summary>
/// Abstract base class for orders (Abstraction in Bridge pattern)
/// This separates order types from payment methods
/// ប្រភេទការបញ្ជាទិញ (Order type abstraction)
/// </summary>
public abstract class Order
{
    protected IPaymentMethod _paymentMethod;
    public int OrderId { get; set; }
    public List<string> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string CustomerName { get; set; } = string.Empty;

    protected Order(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public void SetPaymentMethod(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public abstract string GetOrderType();
    
    public virtual bool ProcessPayment()
    {
        Console.WriteLine($"Processing {GetOrderType()} order payment...");
        return _paymentMethod.ProcessPayment(TotalAmount);
    }

    public virtual string GetOrderSummary()
    {
        return $"{GetOrderType()} Order #{OrderId} - Total: ${TotalAmount:F2} - Payment: {_paymentMethod.GetPaymentMethodName()}";
    }
}

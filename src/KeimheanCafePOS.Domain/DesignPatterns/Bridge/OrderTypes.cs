namespace KeimheanCafePOS.Domain.DesignPatterns.Bridge;

/// <summary>
/// Dine-in order (Refined Abstraction)
/// ការបញ្ជាទិញញ៉ាំនៅហាង (Dine-in order)
/// </summary>
public class DineInOrder : Order
{
    public int TableNumber { get; set; }

    public DineInOrder(IPaymentMethod paymentMethod) : base(paymentMethod)
    {
    }

    public override string GetOrderType() => "Dine-In";

    public override string GetOrderSummary()
    {
        return $"{base.GetOrderSummary()} - Table: {TableNumber}";
    }
}

/// <summary>
/// Take-out order (Refined Abstraction)
/// ការបញ្ជាទិញយកទៅញ៉ាំ (Take-out order)
/// </summary>
public class TakeOutOrder : Order
{
    public string PickupTime { get; set; } = string.Empty;

    public TakeOutOrder(IPaymentMethod paymentMethod) : base(paymentMethod)
    {
    }

    public override string GetOrderType() => "Take-Out";

    public override string GetOrderSummary()
    {
        return $"{base.GetOrderSummary()} - Pickup: {PickupTime}";
    }
}

/// <summary>
/// Delivery order (Refined Abstraction)
/// ការបញ្ជាទិញដឹកជញ្ជូន (Delivery order)
/// </summary>
public class DeliveryOrder : Order
{
    public string DeliveryAddress { get; set; } = string.Empty;
    public decimal DeliveryFee { get; set; }

    public DeliveryOrder(IPaymentMethod paymentMethod) : base(paymentMethod)
    {
    }

    public override string GetOrderType() => "Delivery";

    public override bool ProcessPayment()
    {
        Console.WriteLine($"Processing delivery fee: ${DeliveryFee:F2}");
        return _paymentMethod.ProcessPayment(TotalAmount + DeliveryFee);
    }

    public override string GetOrderSummary()
    {
        return $"{base.GetOrderSummary()} - Delivery to: {DeliveryAddress} - Fee: ${DeliveryFee:F2}";
    }
}

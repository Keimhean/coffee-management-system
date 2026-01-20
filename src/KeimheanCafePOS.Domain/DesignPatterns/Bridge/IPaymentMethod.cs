namespace KeimheanCafePOS.Domain.DesignPatterns.Bridge;

/// <summary>
/// Interface for payment methods (Implementation interface in Bridge pattern)
/// វិធីបង់ប្រាក់ (Payment method interface)
/// </summary>
public interface IPaymentMethod
{
    string GetPaymentMethodName();
    bool ProcessPayment(decimal amount);
    string GetTransactionDetails();
}

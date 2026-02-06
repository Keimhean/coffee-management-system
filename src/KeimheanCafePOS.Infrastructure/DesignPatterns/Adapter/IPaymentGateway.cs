namespace KeimheanCafePOS.Infrastructure.DesignPatterns.Adapter;

/// <summary>
/// Target interface for unified payment gateway integration
/// This is what our system expects from all payment gateways
/// ចំណុចប្រទាក់ថាមវន្តបង់ប្រាក់ (Payment gateway interface)
/// </summary>
public interface IPaymentGateway
{
    string GetGatewayName();
    Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request);
    Task<RefundResult> RefundPaymentAsync(string transactionId, decimal amount);
    Task<TransactionStatus> GetTransactionStatusAsync(string transactionId);
}

public class PaymentRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string CardNumber { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    public Dictionary<string, string> Metadata { get; set; } = new();
}

public class PaymentResult
{
    public bool Success { get; set; }
    public string TransactionId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public decimal AmountCharged { get; set; }
    public DateTime ProcessedAt { get; set; }
}

public class RefundResult
{
    public bool Success { get; set; }
    public string RefundId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public decimal AmountRefunded { get; set; }
}

public enum TransactionStatus
{
    Pending,
    Processing,
    Completed,
    Failed,
    Refunded
}

namespace KeimheanCafePOS.Infrastructure.DesignPatterns.Adapter;

/// <summary>
/// Simulated third-party Stripe payment API (Adaptee)
/// This represents an external library with its own interface
/// </summary>
public class StripePaymentService
{
    public StripeChargeResult Charge(string token, int amountInCents, string currency)
    {
        // Simulate Stripe API call
        Console.WriteLine($"Stripe: Charging {amountInCents} cents in {currency}");
        return new StripeChargeResult
        {
            Id = $"ch_{Guid.NewGuid().ToString().Substring(0, 24)}",
            Paid = true,
            Amount = amountInCents,
            Created = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };
    }

    public StripeRefundResult Refund(string chargeId, int amountInCents)
    {
        Console.WriteLine($"Stripe: Refunding {amountInCents} cents for charge {chargeId}");
        return new StripeRefundResult
        {
            Id = $"re_{Guid.NewGuid().ToString().Substring(0, 24)}",
            Amount = amountInCents,
            Status = "succeeded"
        };
    }

    public StripeChargeResult GetCharge(string chargeId)
    {
        return new StripeChargeResult
        {
            Id = chargeId,
            Paid = true,
            Amount = 1000,
            Created = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };
    }
}

public class StripeChargeResult
{
    public string Id { get; set; } = string.Empty;
    public bool Paid { get; set; }
    public int Amount { get; set; }
    public long Created { get; set; }
}

public class StripeRefundResult
{
    public string Id { get; set; } = string.Empty;
    public int Amount { get; set; }
    public string Status { get; set; } = string.Empty;
}

/// <summary>
/// Simulated third-party PayPal payment API (Adaptee)
/// </summary>
public class PayPalPaymentService
{
    public PayPalPaymentResponse CreatePayment(PayPalPaymentRequest request)
    {
        Console.WriteLine($"PayPal: Creating payment for {request.Amount} {request.Currency}");
        return new PayPalPaymentResponse
        {
            PaymentId = $"PAY-{Guid.NewGuid().ToString()}",
            State = "approved",
            Amount = request.Amount,
            CreateTime = DateTime.UtcNow.ToString("o")
        };
    }

    public PayPalRefundResponse RefundTransaction(string paymentId, decimal amount)
    {
        Console.WriteLine($"PayPal: Refunding {amount} for payment {paymentId}");
        return new PayPalRefundResponse
        {
            RefundId = $"REF-{Guid.NewGuid().ToString()}",
            State = "completed",
            Amount = amount
        };
    }

    public PayPalPaymentResponse GetPaymentDetails(string paymentId)
    {
        return new PayPalPaymentResponse
        {
            PaymentId = paymentId,
            State = "approved",
            Amount = 10.00m,
            CreateTime = DateTime.UtcNow.ToString("o")
        };
    }
}

public class PayPalPaymentRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string Intent { get; set; } = "sale";
}

public class PayPalPaymentResponse
{
    public string PaymentId { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string CreateTime { get; set; } = string.Empty;
}

public class PayPalRefundResponse
{
    public string RefundId { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

/// <summary>
/// Simulated third-party ABA (Advanced Bank of Asia - Cambodia) payment API (Adaptee)
/// </summary>
public class ABAPaymentService
{
    public ABATransactionResult ProcessTransaction(ABATransactionRequest request)
    {
        Console.WriteLine($"ABA Pay: Processing {request.Amount} {request.Currency}");
        return new ABATransactionResult
        {
            TransactionNumber = $"TXN{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}",
            ResultCode = "00", // Success code
            ResultMessage = "Success",
            TransactionAmount = request.Amount
        };
    }

    public ABARefundResult RequestRefund(string transactionNumber, decimal amount)
    {
        Console.WriteLine($"ABA Pay: Refunding {amount} for transaction {transactionNumber}");
        return new ABARefundResult
        {
            RefundNumber = $"RFD{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}",
            ResultCode = "00",
            RefundAmount = amount
        };
    }

    public ABATransactionResult QueryTransaction(string transactionNumber)
    {
        return new ABATransactionResult
        {
            TransactionNumber = transactionNumber,
            ResultCode = "00",
            ResultMessage = "Success",
            TransactionAmount = 10.00m
        };
    }
}

public class ABATransactionRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string MerchantId { get; set; } = string.Empty;
}

public class ABATransactionResult
{
    public string TransactionNumber { get; set; } = string.Empty;
    public string ResultCode { get; set; } = string.Empty;
    public string ResultMessage { get; set; } = string.Empty;
    public decimal TransactionAmount { get; set; }
}

public class ABARefundResult
{
    public string RefundNumber { get; set; } = string.Empty;
    public string ResultCode { get; set; } = string.Empty;
    public decimal RefundAmount { get; set; }
}

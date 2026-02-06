namespace KeimheanCafePOS.Infrastructure.DesignPatterns.Adapter;

/// <summary>
/// Adapter for Stripe payment service
/// Adapts Stripe's interface to our unified IPaymentGateway interface
/// អាដាប់ទ័រសម្រាប់ Stripe (Stripe adapter)
/// </summary>
public class StripeAdapter : IPaymentGateway
{
    private readonly StripePaymentService _stripeService;

    public StripeAdapter()
    {
        _stripeService = new StripePaymentService();
    }

    public string GetGatewayName() => "Stripe";

    public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
    {
        await Task.Delay(100); // Simulate network delay

        try
        {
            // Convert dollars to cents (Stripe uses cents)
            int amountInCents = (int)(request.Amount * 100);
            
            // Simulate creating a token from card details
            string token = $"tok_{Guid.NewGuid().ToString().Substring(0, 24)}";

            var stripeResult = _stripeService.Charge(token, amountInCents, request.Currency);

            return new PaymentResult
            {
                Success = stripeResult.Paid,
                TransactionId = stripeResult.Id,
                Message = stripeResult.Paid ? "Payment successful" : "Payment failed",
                AmountCharged = request.Amount,
                ProcessedAt = DateTimeOffset.FromUnixTimeSeconds(stripeResult.Created).DateTime
            };
        }
        catch (Exception ex)
        {
            return new PaymentResult
            {
                Success = false,
                Message = $"Stripe error: {ex.Message}",
                ProcessedAt = DateTime.UtcNow
            };
        }
    }

    public async Task<RefundResult> RefundPaymentAsync(string transactionId, decimal amount)
    {
        await Task.Delay(100); // Simulate network delay

        try
        {
            int amountInCents = (int)(amount * 100);
            var refundResult = _stripeService.Refund(transactionId, amountInCents);

            return new RefundResult
            {
                Success = refundResult.Status == "succeeded",
                RefundId = refundResult.Id,
                Message = $"Refund {refundResult.Status}",
                AmountRefunded = amount
            };
        }
        catch (Exception ex)
        {
            return new RefundResult
            {
                Success = false,
                Message = $"Stripe refund error: {ex.Message}"
            };
        }
    }

    public async Task<TransactionStatus> GetTransactionStatusAsync(string transactionId)
    {
        await Task.Delay(50); // Simulate network delay

        var charge = _stripeService.GetCharge(transactionId);
        return charge.Paid ? TransactionStatus.Completed : TransactionStatus.Failed;
    }
}

/// <summary>
/// Adapter for PayPal payment service
/// Adapts PayPal's interface to our unified IPaymentGateway interface
/// អាដាប់ទ័រសម្រាប់ PayPal (PayPal adapter)
/// </summary>
public class PayPalAdapter : IPaymentGateway
{
    private readonly PayPalPaymentService _paypalService;

    public PayPalAdapter()
    {
        _paypalService = new PayPalPaymentService();
    }

    public string GetGatewayName() => "PayPal";

    public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
    {
        await Task.Delay(150); // Simulate network delay

        try
        {
            var paypalRequest = new PayPalPaymentRequest
            {
                Amount = request.Amount,
                Currency = request.Currency,
                Intent = "sale"
            };

            var paypalResult = _paypalService.CreatePayment(paypalRequest);

            return new PaymentResult
            {
                Success = paypalResult.State == "approved",
                TransactionId = paypalResult.PaymentId,
                Message = $"PayPal payment {paypalResult.State}",
                AmountCharged = request.Amount,
                ProcessedAt = DateTime.Parse(paypalResult.CreateTime)
            };
        }
        catch (Exception ex)
        {
            return new PaymentResult
            {
                Success = false,
                Message = $"PayPal error: {ex.Message}",
                ProcessedAt = DateTime.UtcNow
            };
        }
    }

    public async Task<RefundResult> RefundPaymentAsync(string transactionId, decimal amount)
    {
        await Task.Delay(150); // Simulate network delay

        try
        {
            var refundResult = _paypalService.RefundTransaction(transactionId, amount);

            return new RefundResult
            {
                Success = refundResult.State == "completed",
                RefundId = refundResult.RefundId,
                Message = $"PayPal refund {refundResult.State}",
                AmountRefunded = amount
            };
        }
        catch (Exception ex)
        {
            return new RefundResult
            {
                Success = false,
                Message = $"PayPal refund error: {ex.Message}"
            };
        }
    }

    public async Task<TransactionStatus> GetTransactionStatusAsync(string transactionId)
    {
        await Task.Delay(75); // Simulate network delay

        var payment = _paypalService.GetPaymentDetails(transactionId);
        
        return payment.State switch
        {
            "approved" => TransactionStatus.Completed,
            "pending" => TransactionStatus.Pending,
            "failed" => TransactionStatus.Failed,
            _ => TransactionStatus.Failed
        };
    }
}

/// <summary>
/// Adapter for ABA Pay (Advanced Bank of Asia - Cambodia local payment)
/// Adapts ABA's interface to our unified IPaymentGateway interface
/// អាដាប់ទ័រសម្រាប់ ABA Pay (ABA Pay adapter)
/// </summary>
public class ABAAdapter : IPaymentGateway
{
    private readonly ABAPaymentService _abaService;

    public ABAAdapter()
    {
        _abaService = new ABAPaymentService();
    }

    public string GetGatewayName() => "ABA Pay";

    public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
    {
        await Task.Delay(120); // Simulate network delay

        try
        {
            var abaRequest = new ABATransactionRequest
            {
                Amount = request.Amount,
                Currency = request.Currency,
                MerchantId = "KEIMHEAN_CAFE"
            };

            var abaResult = _abaService.ProcessTransaction(abaRequest);

            return new PaymentResult
            {
                Success = abaResult.ResultCode == "00",
                TransactionId = abaResult.TransactionNumber,
                Message = abaResult.ResultMessage,
                AmountCharged = request.Amount,
                ProcessedAt = DateTime.UtcNow
            };
        }
        catch (Exception ex)
        {
            return new PaymentResult
            {
                Success = false,
                Message = $"ABA Pay error: {ex.Message}",
                ProcessedAt = DateTime.UtcNow
            };
        }
    }

    public async Task<RefundResult> RefundPaymentAsync(string transactionId, decimal amount)
    {
        await Task.Delay(120); // Simulate network delay

        try
        {
            var refundResult = _abaService.RequestRefund(transactionId, amount);

            return new RefundResult
            {
                Success = refundResult.ResultCode == "00",
                RefundId = refundResult.RefundNumber,
                Message = refundResult.ResultCode == "00" ? "Refund successful" : "Refund failed",
                AmountRefunded = amount
            };
        }
        catch (Exception ex)
        {
            return new RefundResult
            {
                Success = false,
                Message = $"ABA Pay refund error: {ex.Message}"
            };
        }
    }

    public async Task<TransactionStatus> GetTransactionStatusAsync(string transactionId)
    {
        await Task.Delay(60); // Simulate network delay

        var transaction = _abaService.QueryTransaction(transactionId);
        
        return transaction.ResultCode == "00" 
            ? TransactionStatus.Completed 
            : TransactionStatus.Failed;
    }
}

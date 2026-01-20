namespace KeimheanCafePOS.Domain.DesignPatterns.Bridge;

/// <summary>
/// Cash payment implementation
/// បង់ប្រាក់ជាសាច់ប្រាក់ (Cash payment)
/// </summary>
public class CashPayment : IPaymentMethod
{
    private decimal _amountReceived;
    private decimal _change;

    public string GetPaymentMethodName() => "Cash";

    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing cash payment of ${amount:F2}");
        return true;
    }

    public void SetAmountReceived(decimal amount)
    {
        _amountReceived = amount;
    }

    public decimal CalculateChange(decimal total)
    {
        _change = _amountReceived - total;
        return _change;
    }

    public string GetTransactionDetails()
    {
        return $"Cash Payment - Received: ${_amountReceived:F2}, Change: ${_change:F2}";
    }
}

/// <summary>
/// Credit card payment implementation
/// បង់ប្រាក់តាមកាតឥណពន្ធ (Credit card payment)
/// </summary>
public class CreditCardPayment : IPaymentMethod
{
    public string CardNumber { get; set; } = string.Empty;
    public string CardHolderName { get; set; } = string.Empty;
    private string _transactionId = string.Empty;

    public string GetPaymentMethodName() => "Credit Card";

    public bool ProcessPayment(decimal amount)
    {
        _transactionId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        Console.WriteLine($"Processing credit card payment of ${amount:F2}");
        Console.WriteLine($"Transaction ID: {_transactionId}");
        return true;
    }

    public string GetTransactionDetails()
    {
        return $"Credit Card Payment - Card: ****{CardNumber.Substring(CardNumber.Length - 4)} - Transaction: {_transactionId}";
    }
}

/// <summary>
/// Mobile payment implementation (e.g., ABA, Wing, Pi Pay)
/// បង់ប្រាក់តាមទូរសព្ទ (Mobile payment)
/// </summary>
public class MobilePayment : IPaymentMethod
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty; // ABA, Wing, Pi Pay
    private string _transactionId = string.Empty;

    public string GetPaymentMethodName() => $"Mobile Payment ({Provider})";

    public bool ProcessPayment(decimal amount)
    {
        _transactionId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        Console.WriteLine($"Processing mobile payment via {Provider} of ${amount:F2}");
        Console.WriteLine($"Phone: {PhoneNumber} - Transaction ID: {_transactionId}");
        return true;
    }

    public string GetTransactionDetails()
    {
        return $"Mobile Payment ({Provider}) - Phone: {PhoneNumber} - Transaction: {_transactionId}";
    }
}

/// <summary>
/// Gift card payment implementation
/// បង់ប្រាក់តាមកាតអំណោយ (Gift card payment)
/// </summary>
public class GiftCardPayment : IPaymentMethod
{
    public string GiftCardNumber { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    private decimal _remainingBalance;

    public string GetPaymentMethodName() => "Gift Card";

    public bool ProcessPayment(decimal amount)
    {
        if (Balance < amount)
        {
            Console.WriteLine($"Insufficient gift card balance. Balance: ${Balance:F2}, Required: ${amount:F2}");
            return false;
        }

        _remainingBalance = Balance - amount;
        Console.WriteLine($"Processing gift card payment of ${amount:F2}");
        Console.WriteLine($"Remaining balance: ${_remainingBalance:F2}");
        return true;
    }

    public string GetTransactionDetails()
    {
        return $"Gift Card Payment - Card: ****{GiftCardNumber.Substring(GiftCardNumber.Length - 4)} - Remaining: ${_remainingBalance:F2}";
    }
}

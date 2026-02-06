using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeimheanCafePOS.Domain.Entities;

/// <summary>
/// Represents a payment transaction (tracks payment method and gateway usage)
/// ប្រតិបត្តិការបង់ប្រាក់ (Payment transaction)
/// </summary>
[Table("payment_transactions")]
public class PaymentTransaction
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("TransactionNumber")]
    public string TransactionNumber { get; set; } = string.Empty;

    [Required]
    [Column("OrderId")]
    public int OrderId { get; set; }

    [Required]
    [Column("PaymentMethod")]
    public PaymentMethod PaymentMethod { get; set; }

    [MaxLength(50)]
    [Column("PaymentGateway")]
    public string? PaymentGateway { get; set; } // Stripe, PayPal, ABA, etc.

    [Required]
    [Column("Amount")]
    public decimal Amount { get; set; }

    [Required]
    [Column("Status")]
    public PaymentTransactionStatus Status { get; set; } = PaymentTransactionStatus.Pending;

    [MaxLength(100)]
    [Column("GatewayTransactionId")]
    public string? GatewayTransactionId { get; set; }

    [MaxLength(500)]
    [Column("Notes")]
    public string? Notes { get; set; }

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("ProcessedAt")]
    public DateTime? ProcessedAt { get; set; }

    // Navigation property
    public virtual Order? Order { get; set; }
}

public enum PaymentMethod
{
    Cash = 0,
    CreditCard = 1,
    MobilePayment = 2,
    GiftCard = 3,
    BankTransfer = 4
}

public enum PaymentTransactionStatus
{
    Pending = 0,
    Processing = 1,
    Completed = 2,
    Failed = 3,
    Refunded = 4
}

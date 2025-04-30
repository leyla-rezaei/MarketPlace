using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.Invoices;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.PspLog;

[Table(nameof(PspSadadLog), Schema = nameof(SchemaConsts.payment))]
public class PspSadadLog : BaseEntity
{
    public long Number { get; set; }

    public Guid? InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public decimal Amount { get; set; }
   
    public string Token { get; set; }
    public string MerchantId { get; set; }
    public string ResCodePaymentRequest { get; set; }
    public string ResCodePaymentVerify { get; set; }
    public DateTimeOffset PaymentRequestedOn { get; set; }
    public DateTimeOffset? BackFromBankOn { get; set; }
    public DateTimeOffset? VerifyRequestedOn { get; set; }
    public DateTimeOffset? VerifiedOn { get; set; }
    public bool PaymentSuccessful { get; set; }
}

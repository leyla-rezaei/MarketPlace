using MarketPlace.Domain.Entities.Orders.Invoices;

namespace MarketPlace.Dto.PspLog
{
    public class PspSadadLogResponseDto
    {
        public Guid Id { get; set; }
        public long Number { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public decimal Amount { get; set; }
        public string MerchantId { get; set; }
        public string ResCodePaymentRequest { get; set; }
        public string ResCodePaymentVerify { get; set; }
        public string Token { get; set; }
        public DateTimeOffset PaymentRequestedOn { get; set; }
        public DateTimeOffset BackFromBankOn { get; set; }
        public DateTimeOffset VerifyRequestedOn { get; set; }
        public DateTimeOffset VerifiedOn { get; set; }
        public bool PaymentSuccessful { get; set; }
    }
}

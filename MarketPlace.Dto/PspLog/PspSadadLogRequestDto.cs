namespace MarketPlace.Dto.PspLog
{
    public class PspSadadLogRequestDto
    {
        public long Number { get; set; }
        public Guid InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Token { get; set; }
        public DateTimeOffset? PaymentRequestedOn { get; set; }
        public DateTimeOffset? BackFromBankOn { get; set; }
        public DateTimeOffset? VerifyRequestedOn { get; set; }
        public DateTimeOffset? VerifiedOn { get; set; }
        public bool PaymentSuccessful { get; set; }
        public string MerchantId { get; set; }
        public string ResCodePaymentRequest { get; set; }
        public string ResCodePaymentVerify { get; set; }
    }
}

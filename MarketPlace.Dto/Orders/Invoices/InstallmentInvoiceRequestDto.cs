namespace MarketPlace.Dto.Orders.Invoices
{
    public class InstallmentInvoiceRequestDto
    {
        public Guid ShoppingCardDetailId { get; set; }
        public uint InstallmentNumber { get; set; }
        public Guid PriceId { get; set; }
        public decimal Payable { get; set; }
        public bool IsPayed { get; set; }
        public DateTimeOffset PaidOn { get; set; }
    }
}

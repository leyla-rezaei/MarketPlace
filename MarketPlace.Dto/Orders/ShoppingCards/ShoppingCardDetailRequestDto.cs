namespace MarketPlace.Dto.Orders.ShoppingCards
{
    public class ShoppingCardDetailRequestDto
    {
        public int Quantity { get; set; }
        public Guid ShoppingCardId { get; set; }
        public Guid ProductId { get; set; }
        public bool IsInstallmentPayment { get; set; }

    }
}

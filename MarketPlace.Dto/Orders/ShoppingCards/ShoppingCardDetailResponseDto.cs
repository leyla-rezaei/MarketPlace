using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.Products;

namespace MarketPlace.Dto.Orders.ShoppingCards
{
    public class ShoppingCardDetailResponseDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public Guid ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public bool IsInstallmentPayment { get; set; }

    }
}

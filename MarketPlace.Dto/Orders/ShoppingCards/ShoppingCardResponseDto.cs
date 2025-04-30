using MarketPlace.Domain.Entities.Account;

namespace MarketPlace.Dto.Orders.ShoppingCards
{
    public class ShoppingCardResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public bool IsOpen { get; set; }
    }
}

using MarketPlace.Domain.Enums.Account;

namespace MarketPlace.Dto.Account
{
    public class UserBussinesResponseDto
    {
        public Guid UserId { get; set; }
        public BussinessType BussinessType { get; set; }
    }
}

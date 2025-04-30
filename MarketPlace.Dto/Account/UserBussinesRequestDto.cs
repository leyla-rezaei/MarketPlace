using MarketPlace.Domain.Enums.Account;

namespace MarketPlace.Dto.Account
{
    public class UserBussinesRequestDto
    {
        public Guid UserId { get; set; }
        public BussinessType BussinessType { get; set; }
    }
}

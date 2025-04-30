using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Account;

namespace MarketPlace.Domain.Entities.Account;

public class UserBussines : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public BussinessType BussinessType{ get; set; }
}

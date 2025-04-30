using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Domain.Entities.Account;

public class UserClaim : IdentityUserClaim<Guid>
{
    public new Guid Id { get; set; }
}

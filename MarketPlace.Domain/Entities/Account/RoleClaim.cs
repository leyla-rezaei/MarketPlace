using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Domain.Entities.Account;

public class RoleClaim : IdentityRoleClaim<Guid>
{
    public new Guid Id { get; set; }
}

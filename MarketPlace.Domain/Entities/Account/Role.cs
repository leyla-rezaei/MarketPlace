using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Infrastructure.Identity.Models;

public class Role : IdentityRole<Guid>, IBaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
    public bool IsArchived { get; set; }


    public ICollection<RoleLocalization> Localizations { get; set; }
}
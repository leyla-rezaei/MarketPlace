using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Users;

[Table(nameof(StoreUserGroup), Schema = nameof(SchemaConsts.store_setting))]
public class StoreUserGroup : BaseEntity
{
    public Guid StoreGroupId { get; set; }
    public StoreGroup StoreGroup { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}

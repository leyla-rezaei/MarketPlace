using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings;

[Table(nameof(StoreAdmin), Schema = nameof(SchemaConsts.store_setting))]
public class StoreAdmin : BaseEntity
{
    public Guid AdminId { get; set; }
    public User Admin { get; set; }

    public Guid StoreId { get; set; }
    public Store Store { get; set; }
}

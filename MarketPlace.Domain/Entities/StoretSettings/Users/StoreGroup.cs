using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Users;

[Table(nameof(StoreGroup), Schema = nameof(SchemaConsts.store_setting))]
public class StoreGroup : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    #region Navigation properties
    public ICollection<StoreUserGroup> StoreUserGroups { get; set; }
    public ICollection<StoreGroupLocalization> Localizations { get; set; }
    #endregion
}

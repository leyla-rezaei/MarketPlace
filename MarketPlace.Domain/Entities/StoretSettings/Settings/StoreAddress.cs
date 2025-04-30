using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreAddress), Schema = nameof(SchemaConsts.store_setting))]
public class StoreAddress : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
 
    public Guid CityId { get; set; }
    public City City { get; set; }

    #region Navigation properties
    public ICollection<StoreAddressLocalization> Localizations { get; set; }
    #endregion
}

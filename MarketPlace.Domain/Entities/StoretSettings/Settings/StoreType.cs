using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreType), Schema = nameof(SchemaConsts.store_setting))]
public class StoreType : BaseEntity
{
    public ICollection<StoreTypeLocalization> Localizations;
}

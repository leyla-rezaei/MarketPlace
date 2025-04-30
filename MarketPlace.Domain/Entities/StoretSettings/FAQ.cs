using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings;

[Table(nameof(FAQ), Schema = nameof(SchemaConsts.store_setting))]
public class FAQ : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public int Order { get; set; }

    public ICollection<FAQLocalization> Localizations { get; set; }

}

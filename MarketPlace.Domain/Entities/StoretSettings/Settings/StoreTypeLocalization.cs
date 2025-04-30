using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings
{
    [Table(nameof(StoreTypeLocalization), Schema = nameof(SchemaConsts.localization))]
    public class StoreTypeLocalization : BaseLocalization
    {
        public string Type { get; set; } = string.Empty;

        public Guid StoreTypeId { get; set; }
        public StoreType StoreType { get; set; }
    }
}

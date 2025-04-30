using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketPlace.Domain.Entities.StoretSettings.Settings
{
    [Table(nameof(StoreGeneralSettingLocalization), Schema = nameof(SchemaConsts.localization))]
    public class StoreGeneralSettingLocalization : BaseLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid StoreGeneralSettingId {  get; set; }   
        public StoreGeneralSetting StoreGeneralSetting { get; set; }
    }
}

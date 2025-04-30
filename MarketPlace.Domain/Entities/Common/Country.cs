using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Common;

[Table(nameof(Country), Schema = nameof(SchemaConsts.@base))]
public class Country : BaseEntity
{
    public string Name { get; set; }

    #region Navigation properties
    public ICollection<Provience> Proviences { get; set; }
    public ICollection<MainBusinessSetting> SiteSettings { get; set; }
    public ICollection<StoreGeneralSetting> GeneralSettings { get; set; }
    #endregion
}

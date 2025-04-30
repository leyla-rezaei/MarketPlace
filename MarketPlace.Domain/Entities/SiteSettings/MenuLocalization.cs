using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.SiteSettings
{
    [Table(nameof(MenuLocalization), Schema = nameof(SchemaConsts.localization))]
    public class MenuLocalization : BaseLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid MenuId {  get; set; }
        public Menu Menu { get; set; }
    }
}

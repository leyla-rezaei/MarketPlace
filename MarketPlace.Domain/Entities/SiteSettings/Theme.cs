using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.SiteSettings;

[Table(nameof(Theme), Schema = nameof(SchemaConsts.site_setting))]
public class Theme : BaseEntity
{
}

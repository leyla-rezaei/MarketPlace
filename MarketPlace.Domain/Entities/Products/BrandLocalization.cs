using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products;

[Table(nameof(BrandLocalization), Schema = nameof(SchemaConsts.localization))]

public class BrandLocalization:BaseLocalization
{
    public string Name { get; set; } =string.Empty;
    public string Description { get; set; } = string.Empty;

    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }
}

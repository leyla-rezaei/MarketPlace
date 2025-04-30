using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Enums.MultiMediaFiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media;

[Table(nameof(ProductMultiMedia), Schema = nameof(SchemaConsts.media))]
public class ProductMultiMedia : MultiMediaFile
{
    public ProductMultiMedia()
    {
        MediaContentType = MediaContentType.Product;
    }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public bool IsIndex { get; set; }

    public ICollection<ProductMultiMediaLocalization> Localizations { get; set; }
}

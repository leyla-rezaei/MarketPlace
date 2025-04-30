using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products.ProductTypes;

[Table(nameof(DownloadableFile), Schema = nameof(SchemaConsts.product))]
public class DownloadableFile : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public string FileUrl { get; set; }

    public ICollection<DownloadableFileLocalization> Localizations { get; set; }
}

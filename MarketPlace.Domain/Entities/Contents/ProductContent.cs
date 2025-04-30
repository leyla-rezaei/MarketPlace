using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Enums.Post;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Contents;

[Table(nameof(ProductContent), Schema = nameof(SchemaConsts.content))]

public class ProductContent : Content
{
    public ProductContent()
    {
        ContentType = ContentType.Product;
    }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }


    public new ICollection<ProductContentLocalization> Localizations { get; set; }
}

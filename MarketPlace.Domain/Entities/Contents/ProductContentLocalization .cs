using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Contents
{
    [Table(nameof(ProductContentLocalization), Schema = nameof(SchemaConsts.localization))]
    public class ProductContentLocalization : ContentLocalization
    {
        public Guid ContentId { get; set; }
        public ProductContent Content { get; set; }

        public string ShortDescription { get; set; } = string.Empty;
    }
}

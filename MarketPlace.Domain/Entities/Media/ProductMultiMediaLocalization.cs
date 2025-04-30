using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media
{
    [Table(nameof(ProductMultiMediaLocalization), Schema = nameof(SchemaConsts.localization))]
    public class ProductMultiMediaLocalization :MultiMediaFileLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;

        public Guid ProductMultiMediaId {  get; set; }
        public ProductMultiMedia ProductMultiMedia { get; set; }
    }
}

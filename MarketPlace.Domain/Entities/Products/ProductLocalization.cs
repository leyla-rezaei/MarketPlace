using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketPlace.Domain.Entities.Products
{

    [Table(nameof(ProductLocalization), Schema = nameof(SchemaConsts.localization))]

    public class ProductLocalization : BaseLocalization
    {
        public string PurchaseNote { get; set; } = string.Empty;
        public string PackingDescription { get; set; } = string.Empty;

        public Guid ProductId {  get; set; }
        public Product Product { get; set; }
    }
}

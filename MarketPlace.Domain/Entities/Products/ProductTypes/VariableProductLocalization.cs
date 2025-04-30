using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products.ProductTypes
{
    [Table(nameof(VariableProductLocalization), Schema = nameof(SchemaConsts.localization))]
    public class VariableProductLocalization : BaseLocalization
    {
        public string Description { get; set; } = string.Empty;

        public Guid VariableProductId {  get; set; }
        public VariableProduct VariableProduct { get; set; }
    }
}

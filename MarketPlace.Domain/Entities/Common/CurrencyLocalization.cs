using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Common
{
    [Table(nameof(CurrencyLocalization), Schema = nameof(SchemaConsts.localization))]
    public class CurrencyLocalization : BaseLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Symbole { get; set; } = string.Empty;
        public Guid CurrencyId { get; set; }
        public Currency Currency {  get; set; }
    }
}
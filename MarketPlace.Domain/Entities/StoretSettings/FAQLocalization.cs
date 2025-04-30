using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings
{
    [Table(nameof(FAQLocalization), Schema = nameof(SchemaConsts.localization))]
    public class FAQLocalization :BaseLocalization
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;

        public Guid FAQId {  get; set; }
        public FAQ FAQ { get; set; }
    }
}

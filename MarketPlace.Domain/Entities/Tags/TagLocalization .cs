using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Tags
{
    [Table(nameof(TagLocalization), Schema = nameof(SchemaConsts.localization))]
    public class TagLocalization : BaseLocalization
    {
        public string TagName { get; set; } = string.Empty;

        public Guid TagId {  get; set; }    
        public Tag Tag { get; set; }
    }
}

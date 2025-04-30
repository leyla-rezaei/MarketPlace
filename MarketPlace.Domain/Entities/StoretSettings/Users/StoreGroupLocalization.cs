using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketPlace.Domain.Entities.StoretSettings.Users
{
    [Table(nameof(StoreGroupLocalization), Schema = nameof(SchemaConsts.localization))]
    public class StoreGroupLocalization : BaseLocalization
    {
        public string Title { get; set; } = string.Empty;

        public Guid StoreGroupId {  get; set; }
        public StoreGroup StoreGroup { get; set; }
    }
}
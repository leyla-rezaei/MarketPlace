using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings
{
    [Table(nameof(StoreAddressLocalization), Schema = nameof(SchemaConsts.localization))]
    public class StoreAddressLocalization :BaseLocalization
    {
        public string Address { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public Guid StoreAddressId {  get; set; }
        public StoreAddress StoreAddress { get; set; }
    }
}

using MarketPlace.Domain.Entities.StoretSettings.Settings;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Common;

[Table(nameof(City), Schema = nameof(SchemaConsts.@base))]
public class City : BaseEntity
{
    public Guid CountryStateId { get; set; }
    public Provience CountryState { get; set; }
    public string Name { get; set; }


    #region Navigation properties
    public ICollection<StoreAddress> StoreAddresses { get; set; }
    #endregion
}

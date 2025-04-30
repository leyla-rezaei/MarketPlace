using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Common;

[Table(nameof(Provience), Schema = nameof(SchemaConsts.@base))]

public class Provience : BaseEntity
{
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
    public string Name { get; set; }

    #region Navigation properties
    public ICollection<City> CountryStates { get; set; }
    #endregion
}

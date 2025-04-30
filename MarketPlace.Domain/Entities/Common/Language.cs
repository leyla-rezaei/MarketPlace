using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Common;

[Table(nameof(Language), Schema = nameof(SchemaConsts.@base))]
public class Language : BaseEntity
{
    public string Country { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public string LanguageNameWithItsCharacter { get; set; }

    #region Navigation properties
    #endregion
}

using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Tags;

[Table(nameof(Tag), Schema = nameof(SchemaConsts.tag))]
public class Tag : BaseEntity
{
    public bool IsApproved { get; set; }
    public TagType TagType { get; set; }

    #region Navigation Properties
    public ICollection<PostTag> PostTags { get; set; }
    public ICollection<ProductTag> ProductTags { get; set; }
    public ICollection<TagLocalization> Localizations { get; set; }
    #endregion
}

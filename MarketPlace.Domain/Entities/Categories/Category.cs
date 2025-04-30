using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Categories;

[Table(nameof(Category), Schema = nameof(SchemaConsts.product))]
public class Category : BaseEntity
{
    public Guid? ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }
    public CategoryType CategoryType { get; set; }

    #region Navigation Properties 
    public ICollection<Category> Categories { get; set; }
    public ICollection<CategoryLocalization> Localizations { get; set; }
    #endregion
}

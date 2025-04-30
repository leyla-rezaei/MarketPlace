using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Categories;

[Table(nameof(CategoryLocalization), Schema = nameof(SchemaConsts.localization))]

public class CategoryLocalization : BaseLocalization
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Post;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreWritingSetting), Schema = nameof(SchemaConsts.store_setting))]
public class StoreWritingSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public Guid DefaultPostCategoryId { get; set; }
    public PostCategory DefaultPostCategory { get; set; }

    public PostFormat DefaultPostFormat { get; set; }
}

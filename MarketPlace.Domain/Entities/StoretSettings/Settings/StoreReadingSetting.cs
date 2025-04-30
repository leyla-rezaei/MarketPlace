using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Setting;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreReadingSetting), Schema = nameof(SchemaConsts.store_setting))]
public class StoreReadingSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public HomepageDisplay HomepageDisplay { get; set; }

    public Guid? HomePageId { get; set; }
    public Post HomePage { get; set; }

    public Guid? PostsPageId { get; set; }
    public Post PostsPage { get; set; }

    public int BlogPagesShowAtMost { get; set; }
}

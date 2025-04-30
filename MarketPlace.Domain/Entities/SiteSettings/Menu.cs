using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.SiteSettings;

[Table(nameof(Menu), Schema = nameof(SchemaConsts.site_setting))]
public class Menu : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public MenuType MenuType { get; set; }

    public int Order { get; set; }

    public Guid MenuIconId { get; set; }
    public MenuMultiMedia MenuIcon { get; set; }

    public string Url { get; set; }

    public Guid? PostId { get; set; }
    public Post Post { get; set; }

    public Guid? PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }

    public Guid? ProductId { get; set; }
    public Product Product { get; set; }
    public ICollection<MenuLocalization> Localizations { get; set; }
}

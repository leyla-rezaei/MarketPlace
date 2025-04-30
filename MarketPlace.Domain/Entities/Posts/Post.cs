using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Contents;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Rates;
using MarketPlace.Domain.Entities.SiteSettings;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Enums.Post;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Posts;

[Table(nameof(Post), Schema = nameof(SchemaConsts.post))]
public class Post : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public PublishStatus PublishStatus { get; set; }
    public bool IsSchedulingPublish { get; set; }
    public DateTimeOffset? PublishOn { get; set; }
    public Visibility Visibility { get; set; }
    public PostFormat PostFormat { get; set; }
    public PostType PostType { get; set; }
    public string Password { get; set; }
    public int? Order { get; set; }
    public Guid? ParentId { get; set; }
    public Post Parent { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsCommentsAllowed { get; set; }
    public bool IsAllowPinbacks { get; set; }

    public Guid WriterId { get; set; }
    public User Writer { get; set; }

    public Guid ThemeId { get; set; }
    public Theme Theme { get; set; }

    public int Revision { get; set; }

    public int CommentCount { get; set; }
    public int ViewCount { get; set; }
    public int RevisionCount { get; set; }

    #region Navigation Properties
    public ICollection<PostRate> PostRates { get; set; }
    public ICollection<PostComment> PostComments { get; set; }
    public ICollection<PostContent> PostContents { get; set; }
    public ICollection<PostMultimedia> PostGalleries { get; set; }
    public ICollection<PostCategory> PostCategories { get; set; }
    public ICollection<PostLocalization> Localizations { get; set; }
    #endregion
}

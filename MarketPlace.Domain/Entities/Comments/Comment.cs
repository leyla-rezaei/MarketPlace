using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Rates;
using MarketPlace.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Comments;

[Table(nameof(Comment), Schema = nameof(SchemaConsts.comment))]
public  class Comment : BaseEntity
{
    public CommentStatus CommentStatus { get; set; }

    public string AuthorEmail { get; set; }

    public Guid? UserId { get; set; }
    public User User { get; set; }

    public int IsCommentUsefullCount { get; set; }
    public int IsCommentNotUsefullCount { get; set; }

    public Guid? ReplyedToCommentId { get; set; }
    public Comment ReplyedToComment { get; set; }

    #region Navigation Properties
    public ICollection<CommentRate> CommentRates { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<CommentMultiMedia> CommentGalleries { get; set; }
    public ICollection<CommentPosetiveNegativePoint> CommentPosetiveNegativePoints{ get; set; }
    public ICollection<CommentLocalization> Localizations { get; set; }
    #endregion
}

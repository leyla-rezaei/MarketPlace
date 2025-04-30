using MarketPlace.Domain.Enums.Post;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.SiteSettings;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.Posts
{
    public class PostResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public PublishStatus PublishStatus { get; set; }
        public bool IsSchedulingPublish { get; set; }
        public DateTimeOffset PublishOn { get; set; }
        public Visibility Visibility { get; set; }
        public PostFormat PostFormat { get; set; }
        public PostType PostType { get; set; }
        public string Password { get; set; }
        public int Order { get; set; }
        public Guid ParentId { get; set; }
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

        public List<PostLocalizationDto>? Localizations { get; set; } = new();
    }
}

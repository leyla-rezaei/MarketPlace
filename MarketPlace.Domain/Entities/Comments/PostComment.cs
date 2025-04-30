using MarketPlace.Domain.Entities.Posts;

namespace MarketPlace.Domain.Entities.Comments;

public class PostComment : Comment
{
    public Guid PostId { get; set; }
    public Post Post { get; set; }
}

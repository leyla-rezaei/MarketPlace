using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Content;
using MarketPlace.Domain.Enums.Post;


namespace MarketPlace.Domain.Entities.Contents;

public abstract class Content : BaseEntity
{
    public ContentType ContentType { get; set; }
    public int Order { get; set; }

    public ContentAllowingStatus ContentAllowingStatus { get; set; }  
}

  
using MarketPlace.Domain.Enums.Content;
using MarketPlace.Domain.Enums.Post;


namespace MarketPlace.Dto.Contents
{
    public class ContentResponseDto
    {
        public Guid Id { get; set; }
        public ContentType ContentType { get; set; }
        public int Order { get; set; }

        public ContentAllowingStatus ContentAllowingStatus { get; set; }
        public List<ContentLocalizationDto>? Localizations { get; set; } = new();
    }

    public class ProductContentResponseDto : ContentResponseDto
    {
        public Guid ProductId { get; set; }
        public new List<ProductContentLocalizationDto>? Localizations { get; set; } = new();
    }

    public class PostContenResponseDto : ContentResponseDto
    {
        public Guid PostId { get; set; }
        public new List<PostContentLocalizationDto>? Localizations { get; set; } = new();
    }
}

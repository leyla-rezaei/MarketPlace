using MarketPlace.Domain.Enums.Content;
using MarketPlace.Domain.Enums.Post;
using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MarketPlace.Dto.Contents
{
    public class ContentRequestDto
    {
        public ContentType ContentType { get; set; }
        public int Order { get; set; }
        public ContentAllowingStatus ContentAllowingStatus { get; set; }
        public List<ContentLocalizationDto>? Localizations { get; set; }
    }

    public class ContentLocalizationDto
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class ProductContentRequestDto : ContentRequestDto
    {
        [JsonIgnore]
        [IgnoreDataMember]
        [SwaggerIgnore]
        public Guid ProductId { get; set; }
        public new List<ProductContentLocalizationDto>? Localizations { get; set; }
    }


    public class ProductContentLocalizationDto : ContentLocalizationDto
    {
        public string? ShortDescription { get; set; }
    }

    public class PostContentRequestDto : ContentRequestDto
    {
        public new List<PostContentLocalizationDto>? Localizations { get; set; }
    }

    public class PostContentLocalizationDto : ContentLocalizationDto
    {
        public string? Excerpt { get; set; }
    }
}
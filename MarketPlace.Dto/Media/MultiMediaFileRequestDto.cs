using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Enums.MultiMediaFiles;

namespace MarketPlace.Dto.Media
{
    public class MultiMediaFileRequestDto
    {
        public MediaType MediaType { get; set; }
        public string Url { get; set; }
        public string UniqueUrl { get; set; }

        public long FileSize { get; set; }

        public FileSizeType FileSizeType { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public MediaContentType MediaContentType { get; set; }
        public List<MultiMediaFileLocalizationDto>? Localizations { get; set; }
    }

    public class MultiMediaFileLocalizationDto
    {
        public string Key { get; set; }
        public string FileName { get; set; }
    }

    public class CommentMultiMediaRequestDto : MultiMediaFileRequestDto
    {
        public Guid CommentId { get; set; }

        public CommentMultiMediaRequestDto(MediaContentType mediaContentType)
        {
            MediaContentType = mediaContentType;
        }
    }

    public class MenuMultiMediaRequestDto : MultiMediaFileRequestDto
    {
        public MenuMultiMediaRequestDto(MediaContentType mediaContentType)
        {
            MediaContentType = mediaContentType;
        }

        public string? MenuIconUrl { get; set; }
    }

    public class PostMultimediaRequestDto : MultiMediaFileRequestDto
    {
        public PostMultimediaRequestDto(MediaContentType mediaContentType)
        {
            MediaContentType = mediaContentType;
        }

        public Guid PostId { get; set; }
        public bool IsIndex { get; set; }
        public new List<PostMultimediaLocalizationDto>? Localizations { get; set; }
    }

    public class PostMultimediaLocalizationDto : MultiMediaFileLocalizationDto
    {
        public string Title { get; set; }
        public string Alt { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }

    public class ProductMultiMediaRequestDto : MultiMediaFileRequestDto
    {
        public ProductMultiMediaRequestDto(MediaContentType mediaContentType)
        {
            MediaContentType = mediaContentType;
        }

        public Guid ProductId { get; set; }
        public bool IsIndex { get; set; }
        public new List<ProductMultiMediaLocalizationDto>? Localizations { get; set; }
    }

    public class ProductMultiMediaLocalizationDto : MultiMediaFileLocalizationDto
    {
        public string Title { get; set; }
        public string Alt { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
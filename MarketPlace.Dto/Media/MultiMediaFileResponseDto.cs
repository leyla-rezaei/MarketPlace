using MarketPlace.Domain.Enums.MultiMediaFiles;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.Media
{
    public class MultiMediaFileResponseDto
    {
        public Guid Id { get; set; }
        public MediaType MediaType { get; set; }
        public string Url { get; set; }
        public string UniqueUrl { get; set; }

        public long FileSize { get; set; }
        public string FileName { get; set; }

        public FileSizeType? FileSizeType { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public MediaContentType MediaContentType { get; set; }
        public List<MultiMediaFileLocalizationDto> Localization { get; set; } = new();
    }
}

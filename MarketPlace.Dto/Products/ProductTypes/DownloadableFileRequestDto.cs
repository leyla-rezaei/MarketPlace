namespace MarketPlace.Dto.Products.ProductTypes
{
    public class DownloadableFileRequestDto
    {
        public Guid ProductId { get; set; }
        public string FileUrl { get; set; }
        public List<DownloadableFileLocalizationDto>? Localizations { get; set; }
    }

    public class DownloadableFileLocalizationDto
    {
        public string Key { get; set; }
        public string? FileName { get; set; }
    }
}

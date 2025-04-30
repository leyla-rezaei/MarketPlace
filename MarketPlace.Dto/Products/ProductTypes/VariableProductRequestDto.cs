namespace MarketPlace.Dto.Products.ProductTypes
{
    public class VariableProductRequestDto
    {
        public Guid ProductId { get; set; }
        public bool IsEnabled { get; set; }
        public Guid DownloadableFileId { get; set; }
        public bool IsManageStock { get; set; }
        public Guid ShippingClassId { get; set; }
        public List<VariableProductLocalizationDto>? Localizations { get; set; }
    }

    public class VariableProductLocalizationDto
    {
        public string Key { get; set; }
        public string? Description { get; set; }
    }
}

using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Selling.PayGateSetting
{
    public class ZarinPalSettingResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public bool IsEanbled { get; set; }

        public List<ZarinPalSettingLocalizationDto>? Localizations { get; set; } = new();
    }
}

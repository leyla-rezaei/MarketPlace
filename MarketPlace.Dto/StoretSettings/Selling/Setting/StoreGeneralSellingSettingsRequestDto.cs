using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.StoretSettings.Selling.Setting
{
    public class StoreGeneralSellingSettingsRequestDto
    {
        public Guid StoreId { get; set; }
        public Guid CurrencyId { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public DimensionsUnit DimensionsUnit { get; set; }
        public bool IsEnableStarRatingOnProductReviews { get; set; }
        public bool IsProductStarRatingsRequired { get; set; }
    }
}

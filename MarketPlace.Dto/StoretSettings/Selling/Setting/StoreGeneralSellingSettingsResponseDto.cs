using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.StoretSettings.Selling.Setting
{
    public class StoreGeneralSellingSettingsResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }

        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public DimensionsUnit DimensionsUnit { get; set; }
        public bool IsEnableStarRatingOnProductReviews { get; set; }
        public bool IsProductStarRatingsRequired { get; set; }
    }
}

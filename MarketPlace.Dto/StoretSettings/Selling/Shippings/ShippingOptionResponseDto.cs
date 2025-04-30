using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Selling.Shipping;

namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingOptionResponseDto
    {
        public Guid Id { get; set; }
        public bool IsEnableShippingCalculatorOnCartPage { get; set; }
        public bool HideShippingCostsUntilAddressIsEntered { get; set; }
        public ShippingDestination ShippingDestination { get; set; }
        public bool IsDebugModeEanbled { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
    }
}

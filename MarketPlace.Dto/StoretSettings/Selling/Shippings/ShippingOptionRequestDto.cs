using MarketPlace.Domain.Enums.Selling.Shipping;

namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingOptionRequestDto
    {
        public bool IsEnableShippingCalculatorOnCartPage { get; set; }
        public bool HideShippingCostsUntilAddressIsEntered { get; set; }

        public ShippingDestination ShippingDestination { get; set; }
        public bool IsDebugModeEanbled { get; set; }

        public Guid StoreId { get; set; }
    }
}

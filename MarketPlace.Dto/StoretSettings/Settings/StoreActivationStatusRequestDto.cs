using MarketPlace.Domain.Enums.StoreSetting;

namespace MarketPlace.Dto.StoretSettings.Settings;

public class StoreActivationStatusRequestDto
{
    public Guid StoreId  { get; set; }
    public StoreActivationStatus ActivationStatus { get; set; }
}

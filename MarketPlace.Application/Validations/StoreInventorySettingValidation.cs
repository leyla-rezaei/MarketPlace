using FluentValidation;
using MarketPlace.Dto.StoretSettings.Selling.Setting;

namespace MarketPlace.Application.Validations
{
    public class StoreInventorySettingValidation : AbstractValidator<StoreInventorySettingRequestDto>
    {
        public StoreInventorySettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotEmpty()
                .WithMessage("store id cannot be empty.");

            RuleFor(x => x.IsEnableStockManagement)
                .NotNull();

            RuleFor(x => x.HoldStockInMinutes)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.IsLowStockNotificationsEnable)
                .NotNull();

            RuleFor(x => x.IsOutOfStockNotificationsEnable)
                .NotNull();

            RuleFor(x => x.NotificationRecipientEmail)
                .NotEmpty().When(x => x.IsLowStockNotificationsEnable || x.IsOutOfStockNotificationsEnable)
                .WithMessage("notification recipient email cannot be empty when low stock or out of stock notifications are enabled.")
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.NotificationRecipientEmail))
                .WithMessage("Invalid email address format.");

            RuleFor(x => x.LowStockThreshold)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.OutOfStockThreshold)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.IsOutOfStockHideFromCatalog)
                .InclusiveBetween(0, 1)
                .WithMessage("is out of stock hide from catalog must be 0 or 1.");
        }
    }
}

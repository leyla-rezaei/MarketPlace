using FluentValidation;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Validations
{
    public class StoreLowThresoldNotificationManagmentSettingValidation : AbstractValidator<StoreLowThresoldNotificationManagmentSettingRequestDto>
    {
        public StoreLowThresoldNotificationManagmentSettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotEmpty()
                .WithMessage("store id is required.");

            RuleFor(x => x.LowThresoldLimit)
                 .Must(value => value >= 0);

            RuleFor(x => x.NotificationType)
               .NotNull();
        }
    }
}
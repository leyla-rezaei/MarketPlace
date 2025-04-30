using FluentValidation;
using MarketPlace.Domain.Enums.Setting;
using MarketPlace.Dto.Admin;

namespace MarketPlace.Application.Validations
{
    public class MainBussimnessSettingValidation : AbstractValidator<MainBusinessSettingRequestDto>
    {
        public MainBussimnessSettingValidation()
        {
            RuleFor(x => x.SiteUrl)
                .NotEmpty()
                .Matches(@"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?$")
                .WithMessage("invalid site url format");

            RuleFor(x => x.Domain)
                .NotEmpty();

            RuleFor(x => x.SuperAdministrationEmailAddress)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.NewUserDefaultRoleId)
                .NotEmpty();


            RuleFor(x => x.TimeZoneId)
                .NotEmpty();

            RuleFor(x => x.CustomDateFormat)
                .NotEmpty()
                .When(x => x.DateFormat == DateFormat.Custom);

            RuleFor(x => x.AdminStoreId)
                .NotEmpty();

            RuleFor(x => x.NumberOfCharacteriseToHoldInQueue);
        }
    }
}

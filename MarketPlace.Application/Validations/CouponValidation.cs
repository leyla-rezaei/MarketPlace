using FluentValidation;
using MarketPlace.Dto.StoretSettings.Selling.Promotions;

namespace MarketPlace.Application.Validations
{
    public class CouponValidation : AbstractValidator<CouponRequestDto>
    {
        public CouponValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.DiscountType)
               .NotNull();

            RuleFor(x => x.Percent)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ValidFrom)
                .NotEmpty()
                .LessThanOrEqualTo(x => x.ValidTo)
                .WithMessage("valid from must be less than or equal to valid to.");

            RuleFor(x => x.ValidTo)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.ValidFrom)
                .WithMessage("valid to must be greater than or equal to valid from.");

            RuleFor(x => x.UsableCount)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Usage)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.MinInvoiceLimit)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.MaxInvoiceLimit)
                .GreaterThanOrEqualTo(x => x.MinInvoiceLimit);

            RuleFor(x => x.UserId)
                .NotEmpty().When(x => x.Usage > 0);

            RuleFor(x => x.ProductId)
                .NotEmpty().When(x => x.Usage > 0);
        }
    }
}
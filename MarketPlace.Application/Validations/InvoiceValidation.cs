using FluentValidation;
using MarketPlace.Dto.Orders.Invoices;


namespace MarketPlace.Application.Validations
{
    public class InvoiceValidation : AbstractValidator<InvoiceRequestDto>
    {
        public InvoiceValidation()
        {
            RuleFor(x => x.UserId)
                .NotNull();

            RuleFor(x => x.ShoppingCardId)
                .NotEmpty();

            RuleFor(x => x.CouponId)
                .NotEmpty().When(dto => dto.Discount > 0)
                .WithMessage("coupon id is required when there is a discount.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("amount must be a positive number.");

            RuleFor(x => x.IsPaid)
                .NotNull()
                .WithMessage("paid status cannot be null.");
        }
    }
}
using FluentValidation;
using MarketPlace.Dto.Products;

namespace MarketPlace.Application.Validations
{
    public class ProductSpecialOfferValidation : AbstractValidator<ProductSpecialOfferRequestDto>
    {
        public ProductSpecialOfferValidation()
        {
            RuleFor(X => X.ProductId)
                .NotNull();

            RuleFor(X => X.OfferPrice)
                .GreaterThan(0)
                .WithMessage("offer price must be greater than 0.");

            RuleFor(X => X.Expiration)
                .Must(BeFutureDate)
                .WithMessage("expiration date must be in the future.");
        }

        private bool BeFutureDate(DateTimeOffset expiration)
        {
            return expiration > DateTimeOffset.UtcNow;
        }
    }
}

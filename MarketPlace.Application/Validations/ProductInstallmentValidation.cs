using FluentValidation;
using MarketPlace.Dto.Products.Installment;

namespace MarketPlace.Application.Validations
{
    public class ProductInstallmentValidation : AbstractValidator<ProductInstallmentRequestDto>
    {
        public ProductInstallmentValidation()
        {
            RuleFor(x => x.ProductId)
                .NotNull();

            RuleFor(x => x.BenefitPercent)
                .NotEmpty();
        }
    }
}

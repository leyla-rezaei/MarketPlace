using FluentValidation;
using MarketPlace.Dto.Products.ProductTypes;

namespace MarketPlace.Application.Validations
{
    internal class VariableProductValidation : AbstractValidator<VariableProductRequestDto>
    {

        public VariableProductValidation()
        {
            RuleFor(x => x.ProductId)
                .NotNull();

            RuleFor(x => x.DownloadableFileId)
                .NotEqual(Guid.Empty).When(x => x.DownloadableFileId != null)
                .WithMessage("invalid downloadable file id.");

            RuleFor(x => x.ShippingClassId)
                .NotNull();
        }
    }
}
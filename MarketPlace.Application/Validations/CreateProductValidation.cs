using FluentValidation;
using MarketPlace.Dto.Products;

namespace MarketPlace.Application.Validations
{
    public class CreateProductValidation :AbstractValidator<CreateProductRequestDto>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.ProductRequestDto)
                .NotNull();

            RuleFor(x => x.SalePrice)
                .GreaterThan(0)
                .WithMessage("sale price must be a positive number.");

            RuleFor(x => x.ProductContentRequestDto)
                .NotNull();

            RuleFor(x => x.DownloadableFileRequestDto)
                .NotNull();

            RuleFor(x => x.CategoryIds)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.TagIds)
                .NotNull()
                .NotEmpty();
        }
    }
}
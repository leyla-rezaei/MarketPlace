using FluentValidation;
using MarketPlace.Dto.Products;

namespace MarketPlace.Application.Validations;

public class ProductValidation : AbstractValidator<ProductRequestDto>
{
    public ProductValidation()
    {
        RuleFor(x => x.StoreId).NotNull();

        //add all required properties

        RuleFor(x => x.ProductType).NotNull();

        RuleFor(x => x.BrandId)
            .NotNull()
            .When(x => x.IsOrginalProduct == true)
            .WithMessage("if is orginale product, the brand should select");

        RuleFor(x => x.Password)
            .NotNull()
            .When(x => x.Visibility == Domain.Enums.Visibility.PasswordProtected)
            .WithMessage("if visibility is password protected passwotd is required");

        RuleFor(x => x.PublishOn)
            .NotNull()
            .When(x => x.IsSchedulingPublish == true);

        RuleFor(x => x.StockQuantity)
            .NotNull()
            .When(x=>x.IsManageStock);
    }
}

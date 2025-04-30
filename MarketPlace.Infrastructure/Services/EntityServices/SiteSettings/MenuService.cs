using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.SiteSettings;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.SiteSettings;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.SiteSettings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.SiteSettings
{
    public class MenuService : BaseService<Menu, MenuRequestDto, MenuResponseDto>, IMenuService
    {
        private readonly IValidator<MenuRequestDto> _menuvalidator;
        public MenuService(IBaseRepository<Menu> repository,
            IValidator<MenuRequestDto> menuvalidator) : base(repository)
        {
            _menuvalidator = menuvalidator;
        }

        public async Task<SingleResponse<Menu>> CreateMenu(MenuRequestDto input, CancellationToken cancellationToken)
        {
            var menuValidation = _menuvalidator.Validate(input).GetAllErrorsString();
            if (menuValidation.HasValue()) return (ResponseStatus.ValidationFailed, menuValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isMenuMultiMediaExist = await GetAllAsNoTracking<MenuMultiMedia>().Where(x => x.Id == input.MenuIconId).AnyAsync(cancellationToken);
            if (!isMenuMultiMediaExist) return ResponseStatus.NotFound;

            var isPostExist = await GetAllAsNoTracking<Post>().Where(x => x.Id == input.PostId).AnyAsync(cancellationToken);
            if (!isPostExist) return ResponseStatus.NotFound;

            var isCategoryOfPostExist = await GetAllAsNoTracking<PostCategory>().Where(x => x.Id == input.PostCategoryId).AnyAsync(cancellationToken);

            if (!isCategoryOfPostExist) return ResponseStatus.NotFound;

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            return await CreateMenu(input, cancellationToken);
        }
    }
}
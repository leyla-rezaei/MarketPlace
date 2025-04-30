using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Categories;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Categories;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Categories;

public class CategoryService : BaseService<Category, CategoryRequestDto, CategoryResponseDto>, ICategoryService
{
    public CategoryService(IBaseRepository<Category> repository) : base(repository) { }

    public async Task<JustResponse> CheckCategoryIds(List<Guid> ids, CancellationToken cancellationToken)
    {
        var availableIds = await GetAll().Where(x => ids.Contains(x.Id)).CountAsync(cancellationToken);

        if (ids.Count() == availableIds)
            return ResponseStatus.Success;
        else
            return ResponseStatus.Failed;
    }

    public async Task<ListResponse<CategoryResponseDto>> GetProductCategories(Guid productId, CancellationToken cancellationToken)
    {
        var product = await GetAllAsNoTracking<Product>()
               .Where(x => x.Id == productId)
               .FirstOrDefaultAsync(cancellationToken);

        if (product is null) return ResponseStatus.NotFound;

        var categories = await base.GetAllAsNoTracking<ProductCategory>()
            .Where(category => category.ProductId == productId)
            .Select(category => new CategoryResponseDto
            {
                Id = category.Id,
                CategoryType = CategoryType.Product,
                ParentCategory = category.Category,
                Localizations = category.Category.Localizations.Select(x => new CategoryLocalizationDto
                {
                    Description = x.Description,
                    Slug = x.Slug,
                    Title = x.Title,
                    Key = x.Key
                }).ToList(),
            }).ToListAsync(cancellationToken);

        return categories;
    }
}

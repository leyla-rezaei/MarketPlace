using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Dto.Categories;

namespace MarketPlace.Application.Services.EntityServices.Categories;

public interface ICategoryService : IBaseService<Category, CategoryRequestDto, CategoryResponseDto>
{
    Task<JustResponse> CheckCategoryIds(List<Guid> ids, CancellationToken cancellationToken);
   Task<ListResponse<CategoryResponseDto>> GetProductCategories(Guid productId, CancellationToken cancellationToken);
}

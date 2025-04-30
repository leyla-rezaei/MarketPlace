using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Categories;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Dto.Categories;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Api.Controllers.Categories
{
    public class CategoryController : BaseController<Category, CategoryRequestDto, CategoryResponseDto>
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("[action]/{productId}")]
        public async Task<ListResponse<CategoryResponseDto>> GetProductCategories([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetProductCategories(productId, cancellationToken);
        }
    }
}


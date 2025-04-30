using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.SiteSettings;
using MarketPlace.Domain.Entities.SiteSettings;
using MarketPlace.Dto.SiteSettings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.SiteSettings
{
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<Menu>> CreateMenu(MenuRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateMenu(input, cancellationToken);
        }
    }
}

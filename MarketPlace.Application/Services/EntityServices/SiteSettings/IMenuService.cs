using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.SiteSettings;
using MarketPlace.Dto.SiteSettings;

namespace MarketPlace.Application.Services.EntityServices.SiteSettings
{
    public interface IMenuService
    {
        Task<SingleResponse<Menu>> CreateMenu(MenuRequestDto input, CancellationToken cancellationToken);
    }
}

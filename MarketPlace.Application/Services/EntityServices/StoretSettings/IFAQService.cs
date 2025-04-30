using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Dto.StoretSettings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings
{
    public interface IFAQService
    {
        Task<SingleResponse<FAQ>> CreateFAQ(FAQRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<FAQ>> UpdateFAQ(Guid id, FAQRequestDto input, CancellationToken cancellationToken);
    }
}

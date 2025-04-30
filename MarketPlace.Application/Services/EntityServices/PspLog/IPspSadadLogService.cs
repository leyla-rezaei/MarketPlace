using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.PspLog;
using MarketPlace.Dto.PspLog;

namespace MarketPlace.Application.Services.EntityServices.PspLog
{
    public interface IPspSadadLogService
    {
        Task<SingleResponse<PspSadadLog>> CreatePspSadadLog(PspSadadLogRequestDto input, CancellationToken cancellationToken);
    }
}

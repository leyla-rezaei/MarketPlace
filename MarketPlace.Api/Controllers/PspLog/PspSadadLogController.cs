using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.PspLog;
using MarketPlace.Domain.Entities.PspLog;
using MarketPlace.Dto.PspLog;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.PspLog
{
    public class PspSadadLogController : ControllerBase
    {
        private readonly IPspSadadLogService _service;
        public PspSadadLogController(IPspSadadLogService service)
        {
            _service = service;
        }
        public async Task<SingleResponse<PspSadadLog>> CreatePspSadadLog(PspSadadLogRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreatePspSadadLog(input, cancellationToken); 
        }
    }
}

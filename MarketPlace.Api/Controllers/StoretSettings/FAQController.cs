using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Dto.StoretSettings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IFAQService _service;
        public FAQController(IFAQService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<FAQ>> CreateFAQ(FAQRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateFAQ(input, cancellationToken);   
        }

        [HttpPut("[action]")]
        public async Task<SingleResponse<FAQ>> UpdateFAQ(Guid id, FAQRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.UpdateFAQ(id, input, cancellationToken);
        }
    }
}
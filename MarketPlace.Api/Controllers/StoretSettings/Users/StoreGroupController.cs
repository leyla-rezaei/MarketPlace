using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Users;
using MarketPlace.Dto.StoretSettings.Users;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreGroupController : ControllerBase
    {
        private readonly IStoreGroupService _service;
        public StoreGroupController(IStoreGroupService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreGroup>> CreateStoreGroup(StoreGroupRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreGroup(input, cancellationToken); 
        }
    }
}

using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.StoretSettings.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAddressController : ControllerBase
    {
        private readonly IStoreAddressService _service;
        public StoreAddressController(IStoreAddressService service) 
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreAddress>> CreateStoreAddress(StoreAddressRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreAddress(input, cancellationToken);
        }
    }
}

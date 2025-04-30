using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders;
using MarketPlace.Domain.Entities.Orders;
using MarketPlace.Dto.Orders;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Orders
{
    public class OrderTrackingController : BaseController<OrderTracking, OrderTrackingRequestDto, OrderTrackingResponseDto>
    {
        private readonly IOrderTrackingService _service;
        public OrderTrackingController(IOrderTrackingService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<OrderTracking>> CreateOrderTracking(OrderTrackingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateOrderTracking(input, cancellationToken);
        }
    }
}

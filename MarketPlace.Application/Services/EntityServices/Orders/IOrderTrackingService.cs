using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Orders;
using MarketPlace.Dto.Orders;

namespace MarketPlace.Application.Services.EntityServices.Orders
{
    public interface IOrderTrackingService : IBaseService<OrderTracking, OrderTrackingRequestDto, OrderTrackingResponseDto>
    {
        Task<SingleResponse<OrderTracking>> CreateOrderTracking(OrderTrackingRequestDto input, CancellationToken cancellationToken);
    }
}

using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Orders;
using MarketPlace.Dto.Orders;

namespace MarketPlace.Application.Services.EntityServices.Orders
{
    public interface IOrderNoteService :IBaseService<OrderNote, OrderNoteRequestDto, OrderNoteResponseDto>
    {
        Task<SingleResponse<OrderNote>> CreateOrderNote(OrderNoteRequestDto input, CancellationToken cancellationToken);
    }
}
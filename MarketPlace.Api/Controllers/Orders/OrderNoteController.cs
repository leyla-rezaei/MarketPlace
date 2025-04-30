using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders;
using MarketPlace.Domain.Entities.Orders;
using MarketPlace.Dto.Orders;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Api.Controllers.Orders
{
    public class OrderNoteController : BaseController<OrderNote, OrderNoteRequestDto, OrderNoteResponseDto>
    {
        private readonly IOrderNoteService _service;
        public OrderNoteController(IOrderNoteService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<OrderNote>> CreateOrderNote(OrderNoteRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateOrderNote(input, cancellationToken);
        }
    }
}

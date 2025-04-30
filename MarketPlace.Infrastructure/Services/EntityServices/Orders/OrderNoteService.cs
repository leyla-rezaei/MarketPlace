using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Orders;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Orders;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Orders
{
    public class OrderNoteService : BaseService<OrderNote, OrderNoteRequestDto, OrderNoteResponseDto>, IOrderNoteService
    {
        private readonly IValidator<OrderNoteRequestDto> _orderNoteValidator;
        public OrderNoteService(IBaseRepository<OrderNote> repository,
            IValidator<OrderNoteRequestDto> orderNoteRequestDtoValidator) : base(repository)
        {
            _orderNoteValidator = orderNoteRequestDtoValidator;
        }

        public async Task<SingleResponse<OrderNote>> CreateOrderNote(OrderNoteRequestDto input, CancellationToken cancellationToken)
        {
            var orderNoteValidation = _orderNoteValidator.Validate(input).GetAllErrorsString();
            if (orderNoteValidation.HasValue()) return (ResponseStatus.ValidationFailed, orderNoteValidation);

            var isUserExist = await GetAllAsNoTracking<User>().Where(x => x.Id == input.UserId).AnyAsync(cancellationToken);
            if (!isUserExist) return ResponseStatus.NotFound;

            var isInvoiceExist = await GetAllAsNoTracking<Invoice>().Where(x => x.Id == input.InvoiceId).AnyAsync(cancellationToken);
            if (!isInvoiceExist) return ResponseStatus.NotFound;

            return await CreateOrderNote(input, cancellationToken);
        }
    }
}

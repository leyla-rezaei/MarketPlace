using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders;
using MarketPlace.Domain.Entities.Orders;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Orders;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Orders
{
    public class OrderTrackingService : BaseService<OrderTracking, OrderTrackingRequestDto, OrderTrackingResponseDto>, IOrderTrackingService
    {
        private readonly IValidator<OrderTrackingRequestDto> _orderTrackingValidator;
        public OrderTrackingService(IBaseRepository<OrderTracking> repository,
            IValidator<OrderTrackingRequestDto> orderTrackingRequestDtoValidator) : base(repository)
        {
            _orderTrackingValidator = orderTrackingRequestDtoValidator;
        }

        public async Task<SingleResponse<OrderTracking>> CreateOrderTracking(OrderTrackingRequestDto input, CancellationToken cancellationToken)
        {
            var orderTrackingValidation = _orderTrackingValidator.Validate(input).GetAllErrorsString();
            if (orderTrackingValidation.HasValue()) return (ResponseStatus.ValidationFailed, orderTrackingValidation);

            var isInvoiceExist = await GetAllAsNoTracking<Invoice>().Where(x => x.Id == input.InvoiceId).AnyAsync(cancellationToken);
            if (!isInvoiceExist) return ResponseStatus.NotFound;

            return await CreateOrderTracking(input, cancellationToken);
        }

    }
}

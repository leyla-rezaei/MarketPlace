using FluentValidation;
using MarketPlace.Dto.Orders;

namespace MarketPlace.Application.Validations
{
    public class OrderTrackingValidation : AbstractValidator<OrderTrackingRequestDto>
    {
        public OrderTrackingValidation()
        {
            RuleFor(x => x.InvoiceId)
                .NotNull();

            RuleFor(x => x.OrderNoteType)
                .NotNull();

            RuleFor(x => x.OrderTracingStatus)
                .NotNull();
        }
    }
}

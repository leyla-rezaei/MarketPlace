using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Enums.Order;

namespace MarketPlace.Dto.Orders
{
    public class OrderTrackingResponseDto
    {
        public Guid Id { get; set; }
        public OrderTracingStatus OrderTracingStatus { get; set; }
        public OrderTrackingType OrderNoteType { get; set; }

        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public List<OrderTrackingLocalizationDto>? Localizations { get; set; } = new();
    }
}

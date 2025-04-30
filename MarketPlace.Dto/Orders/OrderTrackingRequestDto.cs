using MarketPlace.Domain.Enums.Order;

namespace MarketPlace.Dto.Orders
{
    public class OrderTrackingRequestDto
    {
        public OrderTracingStatus OrderTracingStatus { get; set; }
        public OrderTrackingType OrderNoteType { get; set; }
        public Guid InvoiceId { get; set; }
        public List<OrderTrackingLocalizationDto>? Localizations { get; set; }
    }

    public class OrderTrackingLocalizationDto
    {
        public string Key { get; set; }
        public string? Description { get; set; }
    }
}

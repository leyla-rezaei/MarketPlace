using MarketPlace.Domain.Enums.Order;

namespace MarketPlace.Dto.Orders
{
    public class OrderNoteRequestDto
    {
        public OrderNoteType OrderNoteType { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid UserId { get; set; }
        public List<OrderNoteLocalizationDto>? Localizations { get; set; }
    }

    public class OrderNoteLocalizationDto
    {
        public string Key { get; set; } = string.Empty;
        public string? Note { get; set; }
    }
}

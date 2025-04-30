using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Enums.Order;

namespace MarketPlace.Dto.Orders
{
    public class OrderNoteResponseDto
    {
        public Guid Id { get; set; }
        public OrderNoteType OrderNoteType { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<OrderNoteLocalizationDto>? Localizations { get; set; } = new();
    }
}

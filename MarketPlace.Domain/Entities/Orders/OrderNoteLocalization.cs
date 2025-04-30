using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders
{
    [Table(nameof(OrderNoteLocalization), Schema = nameof(SchemaConsts.localization))]
    public class OrderNoteLocalization : BaseLocalization
    {
        public string Note { get; set; } = string.Empty;
        public Guid OrderNoteId {  get; set; }
        public OrderNote OrderNote { get; set; }
    }
}

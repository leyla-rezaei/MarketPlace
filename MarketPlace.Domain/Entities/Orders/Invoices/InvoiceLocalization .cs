using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders.Invoices
{
    [Table(nameof(InvoiceLocalization), Schema = nameof(SchemaConsts.localization))]
    public class InvoiceLocalization :BaseLocalization
    {
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerProvidedNote { get; set; } = string.Empty;

        public Guid InvoiceId {  get; set; }
        public Invoice Invoice { get; set; }
    }
}

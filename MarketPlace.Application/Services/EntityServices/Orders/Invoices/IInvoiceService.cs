using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Dto.Orders.Invoices;

namespace MarketPlace.Application.Services.EntityServices.Orders.Invoices
{
    public interface IInvoiceService :IBaseService<Invoice, InvoiceRequestDto, InvoiceResponseDto>
    {
        Task<SingleResponse<Invoice>> CreateInvoice(InvoiceRequestDto input, CancellationToken cancellationToken);
    }
}

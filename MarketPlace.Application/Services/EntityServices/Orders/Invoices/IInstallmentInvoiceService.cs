using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Dto.Orders.Invoices;

namespace MarketPlace.Application.Services.EntityServices.Orders.Invoices
{
    public interface IInstallmentInvoiceService
    {
        Task<SingleResponse<InstallmentInvoice>> CreateInstallmentInvoice(InstallmentInvoiceRequestDto input, CancellationToken cancellationToken);
    }
}

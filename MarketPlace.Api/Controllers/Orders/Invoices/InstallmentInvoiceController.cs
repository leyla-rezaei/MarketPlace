using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders.Invoices;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Dto.Orders.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Invoices
{
    public class InstallmentInvoiceController :ControllerBase
    {
        private readonly IInstallmentInvoiceService _service;
        public InstallmentInvoiceController(IInstallmentInvoiceService service) 
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<InstallmentInvoice>> CreateInstallmentInvoice(InstallmentInvoiceRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateInstallmentInvoice(input, cancellationToken);
        }
    }
}

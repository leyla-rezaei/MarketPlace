using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders.Invoices;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Dto.Orders.Invoices;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Api.Controllers.Invoices
{
    public class InvoiceController : BaseController<Invoice, InvoiceRequestDto, InvoiceResponseDto>
    {
        private readonly IInvoiceService _service;
        public InvoiceController(IInvoiceService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<Invoice>> CreateInvoice(InvoiceRequestDto input, CancellationToken cancellationToken)
        { 
            return await _service.CreateInvoice(input, cancellationToken);
        }
    }
}

using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders.Invoices;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Orders.Invoices;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Orders.Invoices
{
    public class InvoiceService : BaseService<Invoice, InvoiceRequestDto, InvoiceResponseDto>, IInvoiceService
    {
        private readonly IValidator<InvoiceRequestDto> _invoiceValidator;    
        public InvoiceService(IBaseRepository<Invoice> repository,
            IValidator<InvoiceRequestDto> invoiceValidator) : base(repository)
        { 
            _invoiceValidator = invoiceValidator;
        }

        public  async Task<SingleResponse<Invoice>> CreateInvoice(InvoiceRequestDto input, CancellationToken cancellationToken)
        {
            var invoiceValidation = _invoiceValidator.Validate(input).GetAllErrorsString();
            if (invoiceValidation.HasValue()) return (ResponseStatus.ValidationFailed, invoiceValidation);

            var isUserExist = await GetAllAsNoTracking<User>().Where(x => x.Id == input.UserId).AnyAsync(cancellationToken);
            if (!isUserExist) return ResponseStatus.NotFound;

            var isShoppingCardExist = await GetAllAsNoTracking<ShoppingCard>().Where(x => x.Id == input.ShoppingCardId).AnyAsync(cancellationToken);
            if (!isShoppingCardExist) return ResponseStatus.NotFound;

            return await CreateInvoice(input, cancellationToken);
        }
    }
}
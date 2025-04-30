using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Orders.Invoices;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Orders.Invoices;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.Orders.Invoices
{
    public class InstallmentInvoiceService : BaseService<InstallmentInvoice, InstallmentInvoiceRequestDto, InstallmentInvoiceResponseDto>, IInstallmentInvoiceService
    {
        public InstallmentInvoiceService(IBaseRepository<InstallmentInvoice> repository) : base(repository)
        { }

        public async Task<SingleResponse<InstallmentInvoice>> CreateInstallmentInvoice(InstallmentInvoiceRequestDto input, CancellationToken cancellationToken)
        {

            var isPriceExist = await GetAllAsNoTracking<Price>().Where(x => x.Id == input.PriceId).AnyAsync(cancellationToken);
            if (!isPriceExist) return ResponseStatus.NotFound;

            var isShoppingCardDetailExist = await GetAllAsNoTracking<ShoppingCardDetail>().Where(x => x.Id == input.ShoppingCardDetailId).AnyAsync(cancellationToken);
            if (!isShoppingCardDetailExist) return ResponseStatus.NotFound;

            return await CreateInstallmentInvoice(input, cancellationToken);
        }
    }
}
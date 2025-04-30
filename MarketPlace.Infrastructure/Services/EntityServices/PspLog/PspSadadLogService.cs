using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.PspLog;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Entities.PspLog;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.PspLog;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.PspLog
{
    public class PspSadadLogService : BaseService<PspSadadLog, PspSadadLogRequestDto, PspSadadLogResponseDto>,IPspSadadLogService
    {
        private readonly IValidator<PspSadadLogRequestDto> _pspSadadLogValidator;

        public PspSadadLogService(IBaseRepository<PspSadadLog> repository,
            IValidator<PspSadadLogRequestDto> pspSadadLogValidator) : base(repository)
        {
            _pspSadadLogValidator = pspSadadLogValidator;
        }
        public async Task<SingleResponse<PspSadadLog>> CreatePspSadadLog(PspSadadLogRequestDto input, CancellationToken cancellationToken)
        {
            var pspSadadLogValidation = _pspSadadLogValidator.Validate(input).GetAllErrorsString();
            if (pspSadadLogValidation.HasValue()) return (ResponseStatus.ValidationFailed, pspSadadLogValidation);

            var isInvoiceExist = await GetAllAsNoTracking<Invoice>().Where(x => x.Id == input.InvoiceId).AnyAsync(cancellationToken);
            if (!isInvoiceExist) return ResponseStatus.NotFound;

            return await CreatePspSadadLog(input, cancellationToken);
        }
    }
}
using FluentValidation;
using MarketPlace.Dto.PspLog;

namespace MarketPlace.Application.Validations
{
    public class PspSadadLogValidation : AbstractValidator<PspSadadLogRequestDto>
    {
        public PspSadadLogValidation()
        {
            RuleFor(x => x.Number)
                .GreaterThan(0);

            RuleFor(x => x.InvoiceId)
                .NotNull();

            RuleFor(x => x.Amount)
                .GreaterThan(0);

            RuleFor(x => x.Token)
                .NotEmpty();

            RuleFor(x => x.PaymentRequestedOn)
                .LessThanOrEqualTo(DateTimeOffset.UtcNow)
                .WithMessage("payment requested on must be in the past or present.");

            RuleFor(x => x.BackFromBankOn)
                .LessThanOrEqualTo(DateTimeOffset.UtcNow)
                .When(x => x.BackFromBankOn.HasValue);

            RuleFor(x => x.VerifyRequestedOn)
                .LessThanOrEqualTo(DateTimeOffset.UtcNow)
                .When(x => x.VerifyRequestedOn.HasValue);

            RuleFor(x => x.VerifiedOn)
                .LessThanOrEqualTo(DateTimeOffset.UtcNow)
                .When(x => x.VerifiedOn.HasValue);
            RuleFor(x => x.MerchantId)
                   .NotNull();

            RuleFor(x => x.ResCodePaymentRequest)
                .NotEmpty();

            RuleFor(x => x.ResCodePaymentVerify)
                .NotEmpty();
        }
    }
}

using FluentValidation;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Validations
{
    public class StoreDiscussionSettingValidation : AbstractValidator<StoreDiscussionSettingRequestDto>
    {
        public StoreDiscussionSettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.CloseCommentOnPostOlderThan)
                .Must(x => x.HasValue && x > 0)
                .When(x => x.IsAutomaticallyCloseCommentsOlderThan)
                .WithMessage("close comment on post older than must have a positive value when is automatically close comments older than is true.");

            RuleFor(x => x.HoldQueueWords)
                .NotEmpty();

            RuleFor(x => x.DisallowedCommentKeys)
                .NotEmpty();
        }
    }
}


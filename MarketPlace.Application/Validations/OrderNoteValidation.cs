using FluentValidation;
using MarketPlace.Dto.Orders;


namespace MarketPlace.Application.Validations
{
    public class OrderNoteValidation : AbstractValidator<OrderNoteRequestDto>
    {
        public OrderNoteValidation()
        {
            RuleFor(note => note.UserId)
                .NotNull();

            RuleFor(note => note.InvoiceId)
                .NotNull();

            RuleForEach(x => x.Localizations)
                .SetValidator(new OrderNoteLocalizationValidation()); 
        }

        public class OrderNoteLocalizationValidation : AbstractValidator<OrderNoteLocalizationDto>
        {
            public OrderNoteLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(note => note.Note)
                    .NotEmpty()
                    .WithMessage("order note cannot be empty.");
            }
        }
    }
}

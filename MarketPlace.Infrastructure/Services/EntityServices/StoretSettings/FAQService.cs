using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings;

public class FAQService : BaseService<FAQ, FAQRequestDto, FAQResponseDto>, IFAQService
{
    private readonly IValidator<FAQRequestDto> _fAQValidator;
    private readonly IBaseRepository<FAQ> _repository;
    public FAQService(IBaseRepository<FAQ> repository,
        IValidator<FAQRequestDto> fAQValidator) : base(repository)
    {
        _repository = repository;
        _fAQValidator = fAQValidator;
    }

    public async Task<SingleResponse<FAQ>> CreateFAQ(FAQRequestDto input, CancellationToken cancellationToken)
    {
        var fAQValidation = _fAQValidator.Validate(input).GetAllErrorsString();
        if (fAQValidation.HasValue()) return (ResponseStatus.ValidationFailed, fAQValidation);

        var store = GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).FirstOrDefault();
        if (store == null) return ResponseStatus.StoreNotFound;

        var faq = new FAQ
        {
            StoreId = input.StoreId,
            Order = input.Order,
            Localizations = new List<FAQLocalization>()
        };
    
        var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);

        foreach (var language in languages)
        {
            var localization = new FAQLocalization { Key = language.Key };
            var faqLocalization = input.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();
            if (faqLocalization is not null)
            {
                localization.Answer = faqLocalization.Answer;
                localization.Question = faqLocalization.Question;
            }
            faq.Localizations.Add(localization);
        }

        var response = await Create(input, cancellationToken);

        if (response.Status == ResponseStatus.Success)
        {
            UpdateOrder(response.Result.Id, input);
        }

        return faq;
    }

    public async Task<SingleResponse<FAQ>> UpdateFAQ(Guid id, FAQRequestDto input, CancellationToken cancellationToken)
    {
        var isFAQExist = await GetAll<FAQ>()
            .Include(x => x.Localizations)
            .Where(x => x.Id == id).
            FirstOrDefaultAsync(cancellationToken);

        if (isFAQExist is null) return ResponseStatus.NotFound;

        var resultExist = await GetAllAsNoTracking()
       .Where(x => x.Order == input.Order && x.Id != id).AnyAsync(cancellationToken);

        isFAQExist.StoreId = input.StoreId;
        isFAQExist.Order = input.Order;

        var oldLoacalizations = await GetAll<FAQLocalization>().Where(x => x.FAQId == id).ToListAsync(cancellationToken);
        await Delete(oldLoacalizations, cancellationToken);

        var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);
        foreach (var language in languages)
        {
            var localization = new FAQLocalization { Key = language.Key };
            var faqLocalization = input.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();
            if (faqLocalization is not null)
            {
                localization.Answer = faqLocalization.Answer;
                localization.Question = faqLocalization.Question;
            }
            isFAQExist.Localizations.Add(localization);
        }

        var response = await Update(isFAQExist, cancellationToken);

        if (response.Status == ResponseStatus.Success)
        {
            UpdateOrder(response.Result.Id, input);
        }

        var faq = new FAQ
        {
            Id = isFAQExist.Id,
            StoreId = isFAQExist.StoreId,
            Order = isFAQExist.Order,
            Localizations = isFAQExist.Localizations.Select(x => new FAQLocalization
            { 
                Key = x.Key,
                Question = x.Question,
                Answer = x.Answer
            }).ToList()
        };

        return faq;
    }
    private void UpdateOrder(Guid id, FAQRequestDto input)
    {
        var faqs = GetAll().Where(x => x.StoreId == input.StoreId && x.Order >= input.Order && x.Id != id);
        if (faqs.Any())
        {
            faqs.ExecuteUpdate(s => s.SetProperty(
                n => n.Order,
                n => n.Order + 1
                ));
        }
    }
}

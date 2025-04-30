using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Posts;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using Microsoft.EntityFrameworkCore;
using MarketPlace.Domain.Entities.SiteSettings;
using FluentValidation;
using MarketPlace.Application.Services.EntityServices.Posts;

namespace MarketPlace.Infrastructure.Services.EntityServices.Posts
{
    public class PostService : BaseService<Post, PostRequestDto, PostResponseDto>, IPostService
    {
        IValidator<PostRequestDto> _postValidator;
        public PostService(IBaseRepository<Post> repository,
            IValidator<PostRequestDto> postValidator) : base(repository)
        {
            _postValidator = postValidator;
        }

        public  async Task<SingleResponse<Post>> CreatePost(PostRequestDto input, CancellationToken cancellationToken)
        {
            var postValidation = _postValidator.Validate(input).GetAllErrorsString();
            if (postValidation.HasValue()) return (ResponseStatus.ValidationFailed, postValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isUserExist = await GetAllAsNoTracking<User>().Where(x => x.Id == input.WriterId).AnyAsync(cancellationToken);
            if (!isUserExist) return ResponseStatus.NotFound;

            var isThemeExist = await GetAllAsNoTracking<Theme>().Where(x => x.Id == input.ThemeId).AnyAsync(cancellationToken);
            if (!isThemeExist) return ResponseStatus.NotFound;

            return await CreatePost(input, cancellationToken);
        }
    }
}
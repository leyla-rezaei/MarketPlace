using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Dto.Posts;

namespace MarketPlace.Application.Services.EntityServices.Posts
{
    public interface IPostService
    {
        Task<SingleResponse<Post>> CreatePost(PostRequestDto input, CancellationToken cancellationToken);
    }
}
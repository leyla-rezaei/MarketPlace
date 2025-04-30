using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Posts;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Dto.Posts;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Api.Controllers.Posts
{
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        public PostController(IPostService service) 
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<Post>> CreatePost(PostRequestDto input, CancellationToken cancellationToken)
        { 
            return await _service.CreatePost(input, cancellationToken);
        }
        }
}
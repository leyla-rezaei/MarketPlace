using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TEntity, TInput, TOutput> : ControllerBase
     where TEntity : BaseEntity, new()
     where TInput : class
      where TOutput : class, new()
{
    private readonly IBaseService<TEntity, TInput, TOutput> _service; 

    public BaseController(IBaseService<TEntity, TInput, TOutput> service)
    {
        _service = service;
    }

    [HttpGet]
    public ListResponse<TOutput> Get(CancellationToken cancellationToken)
    {
        return _service.Get(cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<SingleResponse<TOutput>> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _service.Get(id, cancellationToken);
    }

    [HttpPost]
    public async Task<SingleResponse<TEntity>> Post(TInput input, CancellationToken cancellationToken)
    {
        var result = await _service.Create(input, cancellationToken);
        return result;
    }


    [HttpPut]
    public async Task<SingleResponse<TEntity>> Put(Guid id, TInput input, CancellationToken cancellationToken)
    {
        return await _service.Update(id, input, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        return await _service.Delete(id, cancellationToken);
    }
}

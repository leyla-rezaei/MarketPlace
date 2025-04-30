using Mapster;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Common;

public class BaseService<TEntity, TInput, TOutput> : IBaseService<TEntity, TInput, TOutput>
    where TEntity : class, IBaseEntity, new()
    where TInput : class
      where TOutput : class, new()
{
    private readonly IBaseRepository<TEntity> _repository;

    public BaseService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual async Task<SingleResponse<TEntity>> Create(TInput input, CancellationToken cancellationToken)
    {
        TEntity entity = new();

        if (input is not TEntity)
            entity = input.Adapt<TEntity>();

        await _repository.Create(entity, cancellationToken);

        if (entity.Id == Guid.Empty)
        {
            return ResponseStatus.UnknownError;
        }

        return SingleResponse<TEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Create<TCustomEntity, TCustomInput>(TCustomInput input, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity
        where TCustomInput : class
    {
        var entity = input.Adapt<TCustomEntity>();

        await _repository.Create(entity, cancellationToken);

        if (entity.Id == Guid.Empty)
        {
            return ResponseStatus.UnknownError;
        }

        return SingleResponse<TCustomEntity>.Success(entity);
    }

    public virtual async Task<List<TEntity>> CreateRange(List<TEntity> entities, CancellationToken cancellationToken)
    {

        await _repository.CreateRange(entities, cancellationToken);

        return entities;
    }

    public virtual async Task<List<TCustomEntity>> CreateRange<TCustomEntity>(List<TCustomEntity> entities, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity
    {

        await _repository.CreateRange(entities, cancellationToken);

        return entities;
    }

    public virtual async Task<SingleResponse<TEntity>> Update(Guid id, TInput input, CancellationToken cancellationToken)
    {
        var entity = _repository.GetById(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        input.Adapt(entity);
        entity.Id = id;

        await _repository.Update(id, entity, cancellationToken);

        return SingleResponse<TEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Update<TCustomEntity, TCustomInput>(Guid id, TCustomInput input, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity
        where TCustomInput : class
    {
        var entity = _repository.GetById<TCustomEntity>(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        input.Adapt(entity);
        entity.Id = id;

        await _repository.Update(id, entity, cancellationToken);

        return SingleResponse<TCustomEntity>.Success(entity);
    }

    //protected async Task<SingleResponse<TCustomEntity>> Update<TCustomEntity>(TCustomEntity input, CancellationToken cancellationToken)
    //where TCustomEntity : class, IBaseEntity
    //{
    //    var entity = _repository.GetById<TCustomEntity>(input.Id);

    //    if (entity == null)
    //        return ResponseStatus.NotFound;

    //    await _repository.Update(entity.Id, entity, cancellationToken);

    //    return SingleResponse<TCustomEntity>.Success(entity);
    //}


    public virtual async Task<SingleResponse<TCustomEntity>> Update<TCustomEntity>(TCustomEntity input, CancellationToken cancellationToken)
    where TCustomEntity : class, IBaseEntity
    {
        var entity = _repository.GetById<TCustomEntity>(input.Id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        await _repository.Update(entity.Id, entity, cancellationToken);

        return SingleResponse<TCustomEntity>.Success(entity);
    }


    public virtual async Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = _repository.GetById(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        await _repository.Delete(id, cancellationToken);

        return ResponseStatus.Success;
    }

    public virtual async Task<JustResponse> Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity
    {
        var entity = _repository.GetById<TCustomEntity>(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        await _repository.Delete(id, cancellationToken);

        return ResponseStatus.Success;
    }

    public async Task<JustResponse> Delete(List<TEntity> entities, CancellationToken cancellationToken)
    {
        await _repository.Delete(entities, cancellationToken);
        return ResponseStatus.Success;
    }

    public async Task<JustResponse> Delete<TCustomEntity>(List<TCustomEntity> entities, CancellationToken cancellationToken) where TCustomEntity : class, IBaseEntity
    {

        await _repository.Delete(entities, cancellationToken);
        return ResponseStatus.Success;
    }

    public virtual async Task<SingleResponse<TOutput>> Get(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAllAsNoTracking<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            return ResponseStatus.NotFound;
        var result = entity.Adapt<TOutput>();
        return result;
    }


    public ListResponse<TOutput> Get(CancellationToken cancellationToken)
    {
        var entity = _repository.GetAllAsNoTracking<TEntity>().ToList();

        if (entity == null)
            return ResponseStatus.NotFound;
        var result = entity.Adapt<List<TOutput>>();
        return result;
    }


    public virtual IQueryable<TEntity> GetAll()
    {
        return _repository.GetAll();
    }

    public virtual IQueryable<TCustomEntity> GetAll<TCustomEntity>() where TCustomEntity : class, IBaseEntity
    {
        return _repository.GetAll<TCustomEntity>();
    }

    public virtual IQueryable<TEntity> GetAllAsNoTracking()
    {
        return _repository.GetAllAsNoTracking();
    }

    public virtual IQueryable<TCustomEntity> GetAllAsNoTracking<TCustomEntity>() where TCustomEntity : class, IBaseEntity
    {
        return _repository.GetAllAsNoTracking<TCustomEntity>();
    }

    public virtual ListResponse<TCustomOutput> GetAsNoTrackingWithDto<TCusomEntity, TCustomOutput>()
        where TCusomEntity : class, IBaseEntity
        where TCustomOutput : class
    {
        var entities = _repository.GetAllAsNoTracking<TCusomEntity>();

        var result = entities.Adapt<List<TCustomOutput>>();

        return result;
    }
}
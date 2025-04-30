using MarketPlace.Domain.Entities.Common;


namespace MarketPlace.Domain.Repositories.Common;

public interface IBaseRepository<TEntity>
    where TEntity : class, IBaseEntity, new()
{
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
    Task<TCustomEntity> Create<TCustomEntity>(TCustomEntity entity, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity;

    Task<List<TEntity>> CreateRange(List<TEntity> entities, CancellationToken cancellationToken);
    Task<List<TCustomEntity>> CreateRange<TCustomEntity>(List<TCustomEntity> entities, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity;


    Task<TEntity> Update(Guid id, TEntity entity, CancellationToken cancellationToken);
    Task<TCustomEntity> Update<TCustomEntity>(Guid id, TCustomEntity entity, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity;
 
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken) where TCustomEntity : class, IBaseEntity;

    Task Delete(List<TEntity> entities, CancellationToken cancellationToken);
    Task Delete<TCustomEntity>(List<TCustomEntity> entities, CancellationToken cancellationToken) where TCustomEntity : class, IBaseEntity;

    TEntity? GetById(Guid id);
    TCustomEntity? GetById<TCustomEntity>(Guid id)
        where TCustomEntity : class, IBaseEntity;

    IQueryable<TEntity> GetAll();
    IQueryable<TCustomEntity> GetAll<TCustomEntity>() where TCustomEntity : class, IBaseEntity;

    IQueryable<TEntity> GetAllAsNoTracking();
    IQueryable<TCustomEntity> GetAllAsNoTracking<TCustomEntity>() where TCustomEntity : class, IBaseEntity;
}

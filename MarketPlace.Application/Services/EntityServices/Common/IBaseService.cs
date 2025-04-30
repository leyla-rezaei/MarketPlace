using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Common;

namespace MarketPlace.Application.Services.EntityServices.Common
{

    public interface IBaseService<TEntity, TInput, TOutput>
        where TEntity : class, IBaseEntity, new()
        where TInput : class
          where TOutput : class, new()
    {
        Task<SingleResponse<TEntity>> Create(TInput input, CancellationToken cancellationToken);
        Task<SingleResponse<TCustomEntity>> Create<TCustomEntity, TCustomInput>(TCustomInput input, CancellationToken cancellationToken)
            where TCustomEntity : class, IBaseEntity
            where TCustomInput : class;

        Task<SingleResponse<TEntity>> Update(Guid id, TInput input, CancellationToken cancellationToken);
        Task<SingleResponse<TCustomEntity>> Update<TCustomEntity, TCustomInput>(Guid id, TCustomInput input, CancellationToken cancellationToken)
            where TCustomEntity : class, IBaseEntity
            where TCustomInput : class;
        Task<SingleResponse<TCustomEntity>> Update<TCustomEntity>(TCustomEntity input, CancellationToken cancellationToken) where TCustomEntity : class, IBaseEntity;


        Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken);
        Task<JustResponse> Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken) where TCustomEntity : class, IBaseEntity;

        Task<JustResponse> Delete(List<TEntity> entities, CancellationToken cancellationToken);
        Task<JustResponse> Delete<TCustomEntity>(List<TCustomEntity> entities, CancellationToken cancellationToken) where TCustomEntity : class, IBaseEntity;


        Task<SingleResponse<TOutput>> Get(Guid id, CancellationToken cancellationToken);
        ListResponse<TOutput> Get(CancellationToken cancellationToken);
    }
}
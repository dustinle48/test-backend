using System.Linq.Expressions;

namespace TestBackend.Domain.Contracts.Bases;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetById(int id, CancellationToken cancellationToken = default);
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    Task<bool> CheckExists(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestBackend.Domain.Contracts.Bases;

namespace TestBackend.Database.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly TestBackendDbContext Context;

    public Repository(TestBackendDbContext context)
    {
        Context = context;
    }

    public virtual IQueryable<TEntity> GetAll() => Context.Set<TEntity>().AsQueryable();

    public async Task<TEntity?> GetById(int id, CancellationToken cancellationToken = default) => 
        await Context.Set<TEntity>().FindAsync(new object?[] { id }, cancellationToken);


    public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = await Context.Set<TEntity>().AddAsync(entity, cancellationToken);

        await Context.SaveChangesAsync(cancellationToken);

        return entityEntry.Entity;
    }

    public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        
        await Context.Set<TEntity>().(entity, cancellationToken);
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var check = await CheckExists(entity => entity.Id == id, cancellationToken);
        if (check)
        {
            Context.Set<TEntity>().Remove(entity);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> CheckExists(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
    }
}
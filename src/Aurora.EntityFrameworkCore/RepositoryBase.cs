using Aurora.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aurora.EntityFrameworkCore;
public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly AuroraDbContext dbContext;
    private readonly DbSet<TEntity> _entities;

    protected RepositoryBase(AuroraDbContext dbContext)
    {
        this.dbContext = dbContext;
        _entities = dbContext.Set<TEntity>();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
        await Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(ICollection<TEntity> entities)
    {
        _entities.RemoveRange(entities);
        await Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.FirstOrDefaultAsync(predicate);
    }

    /// <inheritdoc />
    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var res = await _entities.Where(predicate).ToListAsync();
        return res;
    }

    /// <inheritdoc />
    public async Task InsertAsync(TEntity entity)
    {

        await _entities.AddAsync(entity);
    }

    /// <inheritdoc />
    public async Task InsertAsync(ICollection<TEntity> entities)
    {
        await _entities.AddRangeAsync(entities);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity entity)
    {
        _entities.Update(entity);
        await Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(ICollection<TEntity> entities)
    {
        _entities.UpdateRange(entities);
        await Task.CompletedTask;
    }
}

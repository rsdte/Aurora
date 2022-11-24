using Aurora.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aurora.EntityFrameworkCore;
public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable
    where TDbContext : DbContext
{
    private readonly TDbContext dbContext;
    private readonly IServiceProvider serviceProvider;

    public bool IsDisposed { get; private set; }
    public bool IsRollback { get; private set; }
    public bool IsCompleted { get; private set; }


    public UnitOfWork(TDbContext dbContext, IServiceProvider serviceProvider)
    {
        this.dbContext = dbContext;
        this.serviceProvider = serviceProvider;
    }


    /// <inheritdoc />
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        IsCompleted = false;
        await dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (IsCompleted)
            return;
        IsCompleted = true;
        await ApplyChangeConventions();
        try
        {
            // 提交事务
            await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            await dbContext.Database.CommitTransactionAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception)
        {
            // 发生异常回滚事务
            await RollbackTransactionAsync(cancellationToken).ConfigureAwait(false);
            throw;
        }
    }

    private Task ApplyChangeConventions()
    {
        dbContext.ChangeTracker.DetectChanges();
        foreach(var entity in dbContext.ChangeTracker.Entries())
        {
            switch (entity.State)
            {
                case EntityState.Deleted:
                    {
                        // 软删除设置。

                        //if (entity.Entity is ISoftDelete entity)
                        //{
                        //    entity.IsDeleted = true;
                        //}
                        //if (entity.Entity is not IHasDeleteCreator deleteCreator) return;
                        //deleteCreator.DeleteTime = DateTime.Now;
                        //deleteCreator.DeleteCreatorId = GetUserId();
                    }
                    break;
                default:
                    break;
            }
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (IsCompleted)
            return;
        IsRollback = true;
        await dbContext.Database.RollbackTransactionAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await ApplyChangeConventions();
        return await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (IsDisposed)
            return;
        IsDisposed = true;
    }
}

using Aurora.Core.DependencyInjections;
using System.Linq.Expressions;

namespace Aurora.Domain;

public interface IRepository<T>: IScopedDependency
    where T : EntityBase
{
    IQueryable<T> GetIQueryable();

    /// <summary>
    /// 获取一个有效数据
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// 获取一个列表
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// 插入一个数据
    /// </summary>
    /// <param name="entity">目标数据</param>
    /// <returns></returns>
    Task InsertAsync(T entity);

    /// <summary>
    /// 批量插入数据
    /// </summary>
    /// <param name="entities">目标数据</param>
    /// <returns></returns>
    Task InsertAsync(ICollection<T> entities);

    /// <summary>
    /// 删除数据
    /// </summary>
    /// <param name="entity">目标数据</param>
    /// <returns></returns>
    Task DeleteAsync(T entity);

    /// <summary>
    /// 批量删除数据
    /// </summary>
    /// <param name="entities">目标数据</param>
    /// <returns></returns>
    Task DeleteAsync(ICollection<T> entities);

    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="entity">目标数据</param>
    /// <returns></returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// 批量删除数据
    /// </summary>
    /// <param name="entities">目标数据</param>
    /// <returns></returns>
    Task UpdateAsync(ICollection<T> entities);

}

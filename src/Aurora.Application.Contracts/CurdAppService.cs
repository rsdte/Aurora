using Aurora.Application.Contracts.Systems;
using Aurora.Core.Common;
using Aurora.Core.DependencyInjections;
using Aurora.Core.Extensions;
using Aurora.Domain;

namespace Aurora.Application.Contracts;

/// <summary>
/// 对指定表进行 curd
/// </summary>
/// <typeparam name="TEntity">表</typeparam>
/// <typeparam name="TInput">查询页</typeparam>
/// <typeparam name="TSave">保存</typeparam>
/// <typeparam name="TUpdate">更新</typeparam>
/// <typeparam name="TResult">查询结果</typeparam>
public abstract class CurdAppServiceBase<TEntity, TInput, TSave, TUpdate, TResult>: IAppService, IScopedDependency
    where TInput: IPageQuery
    where TEntity: EntityBase
    where TSave: TEntity
    where TUpdate: TEntity
{
    private readonly IRepository<TEntity> _repository;

    protected CurdAppServiceBase(IRepository<TEntity> repository)
    {
        _repository = repository;
    }
    
    
    public async virtual Task SaveAsync(TSave input)
    {
        await _repository.InsertAsync(input);
    }

    public async virtual Task DeleteAsync(string id)
    {
        var entity =  await _repository.FindAsync(p => p.Id == id);
        if (entity.IsNullOrEmpty())
            return;

        await _repository.DeleteAsync(entity);
    }

    public async virtual Task UpdateAsync(string id, TUpdate entity)
    {
        var old =  await _repository.FindAsync(p => p.Id == id);
        if (entity.IsNullOrEmpty())
            return;
        entity.Id = id;
        await _repository.UpdateAsync(entity);
    }

    // public async virtual Task<TResult?> GetDataAsync(string id)
    // {
    //     return await _repository.FindAsync(p => p.Id == id);
    // }
    //
    // public async virtual Task<PageResult<TResult>> GetListAsync(PageInput<TInput> input)
    // {
    //     
    // }
}
using BhvrIV.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BhvrIV.Domain.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Task Add(TEntity entity);
    Task Add(List<TEntity> entity);
    void Update(TEntity entity);
    void Update(List<TEntity> entity);

    Task<int> Update(Expression<Func<TEntity, bool>> where,
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> update);

    void Remove(TEntity entity);
    void Remove(List<TEntity> entity);
    Task<int> Remove(Expression<Func<TEntity, bool>>? where = null);

    Task<TEntity?> First(Expression<Func<TEntity, bool>>? where = null,
        List<Expression<Func<TEntity, object>>>? includes = null);

    Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? where = null,
        List<Expression<Func<TEntity, object>>>? includes = null);

    Task<bool> Any(Expression<Func<TEntity, bool>>? where = null,
        List<Expression<Func<TEntity, object>>>? includes = null);

    Task<int> Count(Expression<Func<TEntity, bool>>? where = null,
        List<Expression<Func<TEntity, object>>>? includes = null);

    Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string storedProcedureName, object parameters = null);

}

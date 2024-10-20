using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BhvrIV.Persistence.Ef.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> Entity;
    private readonly IQueryable<TEntity> Table;

    public Repository(AppDbContext dbContext, bool onlyRead)
    {
        _dbContext = dbContext;
        Entity = _dbContext.Set<TEntity>();
        Table = onlyRead ? Table.AsNoTrackingWithIdentityResolution() : Table;
    }

    public async Task Add(TEntity entity)
    {
        await Entity.AddAsync(entity);
    }

    public async Task Add(List<TEntity> entity)
    {
        await Entity.AddRangeAsync(entity);
    }

    public void Update(TEntity entity)
    {
        Entity.Update(entity);
    }

    public void Update(List<TEntity> entity)
    {
        Entity.UpdateRange(entity);
    }

    public async Task<int> Update(Expression<Func<TEntity, bool>> where,
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> update)
    {
        var query = SetConditionsIfNotNull(where);

        return await query.ExecuteUpdateAsync(update);
    }

    public void Remove(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public void Remove(List<TEntity> entity)
    {
        Entity.RemoveRange(entity);
    }

    public async Task<int> Remove(Expression<Func<TEntity, bool>> where = null)
    {
        var query = SetConditionsIfNotNull(where);

        return await query.ExecuteDeleteAsync();
    }

    public async Task<TEntity?> First(Expression<Func<TEntity, bool>> where = null,
        List<Expression<Func<TEntity, object>>>? includes = null)
    {
        var query = SetConditionsIfNotNull(where, includes);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> List(Expression<Func<TEntity, bool>> where = null,
        List<Expression<Func<TEntity, object>>>? includes = null)
    {
        var query = SetConditionsIfNotNull(where, includes);

        return await query.ToListAsync();
    }
    public async Task<bool> Any(Expression<Func<TEntity, bool>> where = null,
        List<Expression<Func<TEntity, object>>>? includes = null)
    {
        var query = SetConditionsIfNotNull(where, includes);

        return await query.AnyAsync(where!);
    }

    public async Task<int> Count(Expression<Func<TEntity, bool>> where = null,
        List<Expression<Func<TEntity, object>>>? includes = null)
    {
        var query = SetConditionsIfNotNull(where, includes);

        return await query.CountAsync(where!);
    }

    #region Privates

    private IQueryable<TEntity> SetConditionsIfNotNull(Expression<Func<TEntity, bool>> where = null,
        List<Expression<Func<TEntity, object>>>? includes = null)
    {
        IQueryable<TEntity> query = Table;

        query = SetWhereIfNotNull(query, where);
        query = SetIncludesIfNotNull(query, includes);

        return query;
    }

    private IQueryable<TEntity> SetWhereIfNotNull(IQueryable<TEntity> query,
        Expression<Func<TEntity, bool>>? where = null)
    {
        if (where != null)
            query = Table.Where(where);

        return query;
    }

    private IQueryable<TEntity> SetIncludesIfNotNull(IQueryable<TEntity> query,
        List<Expression<Func<TEntity, object>>> includes = null)
    {
        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }

    #endregion
}

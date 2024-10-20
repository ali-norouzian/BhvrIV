using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities.Common;
using Dapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Data;
using System.Linq.Expressions;

namespace BhvrIV.Persistence.Sql.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly IDbConnection _dbConnection;

    public Repository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<TEntity>> List()
    {
        var tableName = typeof(TEntity).Name;
        return await _dbConnection.QueryAsync<TEntity>($"SELECT * FROM {tableName}");
    }

    public async Task<TEntity> First(int id)
    {
        var tableName = typeof(TEntity).Name;
        return await _dbConnection.QueryFirstOrDefaultAsync<TEntity>($"SELECT * FROM {tableName} WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string storedProcedureName, object parameters = null)
    {
        return await _dbConnection.QueryAsync<TEntity>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
    }

    public Task Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Add(List<TEntity> entity)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(List<TEntity> entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(Expression<Func<TEntity, bool>> where, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> update)
    {
        throw new NotImplementedException();
    }

    public void Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(List<TEntity> entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> Remove(Expression<Func<TEntity, bool>> where = null)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> First(Expression<Func<TEntity, bool>> where = null, List<Expression<Func<TEntity, object>>> includes = null)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> List(Expression<Func<TEntity, bool>> where = null, List<Expression<Func<TEntity, object>>> includes = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Any(Expression<Func<TEntity, bool>> where = null, List<Expression<Func<TEntity, object>>> includes = null)
    {
        throw new NotImplementedException();
    }

    public Task<int> Count(Expression<Func<TEntity, bool>> where = null, List<Expression<Func<TEntity, object>>> includes = null)
    {
        throw new NotImplementedException();
    }
}
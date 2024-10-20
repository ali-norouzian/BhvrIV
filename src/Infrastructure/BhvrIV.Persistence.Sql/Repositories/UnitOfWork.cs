using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities.Common;
using BhvrIV.Persistence.Sql.Repositories;
using System.Data;

namespace BhvrIV.Persistence.Ef.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _dbConnection;
    private readonly IDbTransaction _dbTransaction;
    private readonly Dictionary<Type, object> _repositories;


    public UnitOfWork(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        _dbConnection.Open();
        _dbTransaction = _dbConnection.BeginTransaction();
        _repositories = new Dictionary<Type, object>();
    }

    public void Dispose()
    {
        _dbTransaction?.Dispose();
        _dbConnection?.Dispose();
    }

    public IRepository<TEntity> GetRepository<TEntity>(bool onlyRead = false) where TEntity : EntityBase
    {
        //var repositories = onlyRead ? _readRepositories : _writeRepositories;
        if (_repositories.ContainsKey(typeof(TEntity)))
            return _repositories[typeof(TEntity)] as Repository<TEntity>;

        var repository = new Repository<TEntity>(onlyRead ? _dbTransaction.Connection : _dbConnection);
        _repositories.Add(typeof(TEntity), repository);

        return repository;
    }

    public async Task<int> SaveChanges()
    {
        try
        {
            // Commit the transaction
            _dbTransaction.Commit();
            return 1; // Return 1 for successful transaction
        }
        catch
        {
            // Rollback transaction on failure
            _dbTransaction.Rollback();
            return 0; // Return 0 if something went wrong
        }
        finally
        {
            _dbConnection.Close();
        }
    }
}

using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities.Common;

namespace BhvrIV.Persistence.Ef.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppReadDbContext _readDbContext;
    private readonly Dictionary<Type, object> _readRepositories;
    private readonly AppWriteDbContext _writeDbContext;
    private readonly Dictionary<Type, object> _writeRepositories;

    public UnitOfWork(AppWriteDbContext writeDbContext, AppReadDbContext readDbContext)
    {
        _writeDbContext = writeDbContext;
        _readDbContext = readDbContext;
        _readRepositories = new Dictionary<Type, object>();
        _writeRepositories = new Dictionary<Type, object>();
    }

    public IRepository<TEntity> GetRepository<TEntity>(bool onlyRead = false) where TEntity : EntityBase
    {
        var repositories = onlyRead ? _readRepositories : _writeRepositories;
        if (repositories.ContainsKey(typeof(TEntity)))
            return repositories[typeof(TEntity)] as Repository<TEntity>;

        var repository = new Repository<TEntity>(onlyRead ? _readDbContext : _writeDbContext, onlyRead);
        repositories.Add(typeof(TEntity), repository);

        return repository;
    }

    public async Task<int> SaveChanges()
    {
        return await _writeDbContext.SaveChangesAsync();
    }
}
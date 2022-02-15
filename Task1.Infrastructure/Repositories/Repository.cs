using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task1.Domain;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Models;
using Task1.Infrastructure.Context;

namespace Task1.Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity, long> where TEntity : EntityName
{
    protected readonly Task1DbContext _db;
    private readonly DbSet<TEntity> _dbSet;

    protected Repository(Task1DbContext db)
    {
        _db = db;
        _dbSet = db.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity> GetById(long id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new ArgumentException(GlobalResource.CanNotFound);
        }

        return entity;
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual async Task Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }


    public void Dispose()
    {
        _db?.Dispose();
    }
}

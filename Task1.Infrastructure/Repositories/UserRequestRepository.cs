using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task1.Domain;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Models;
using Task1.Infrastructure.Context;

namespace Task1.Infrastructure.Repositories;

public class UserRequestRepository : IUserRequestRepository
{
    private readonly Task1DbContext _db;
    private readonly DbSet<UserRequest> _dbSet;

    public UserRequestRepository(Task1DbContext db)
    {
        _db = db;
        _dbSet = db.Set<UserRequest>();
    }

    public virtual async Task<IEnumerable<UserRequest>> Search(Expression<Func<UserRequest, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<UserRequest> GetById(long id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new ArgumentException(GlobalResource.CanNotFound);
        }

        return entity;
    }

    public virtual async Task<List<UserRequest>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task AddAsync(UserRequest entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task Update(UserRequest entity)
    {
        _dbSet.Update(entity);
    }

    public virtual async Task Remove(UserRequest entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<UserRequest, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}


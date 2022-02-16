using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task1.Domain;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Models;
using Task1.Infrastructure.Context;

namespace Task1.Infrastructure.Repositories;

public class UserRequestCourseRepository : IUserRequestCourseRepository
{
    private readonly Task1DbContext _db;
    private readonly DbSet<UserRequestCourse> _dbSet;

    public UserRequestCourseRepository(Task1DbContext db)
    {
        _db = db;
        _dbSet = db.Set<UserRequestCourse>();
    }

    public async Task<IEnumerable<UserRequestCourse>> Search(Expression<Func<UserRequestCourse, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<UserRequestCourse> GetById(long id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new ArgumentException(GlobalResource.CanNotFound);
        }

        return entity;
    }

    public async Task<List<UserRequestCourse>> GetByRequestId(long userRequestId)
    {
        return await _dbSet.AsNoTracking().Where(e => e.UserRequestId == userRequestId).ToListAsync();
    }

    public async Task<List<UserRequestCourse>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(UserRequestCourse entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task Update(UserRequestCourse entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Remove(UserRequestCourse entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<UserRequestCourse, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}

using System.Linq.Expressions;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IRepositories;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task AddAsync(TEntity entity);
    Task<List<TEntity>> GetAll();
    Task<TEntity> GetById(long id);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
}

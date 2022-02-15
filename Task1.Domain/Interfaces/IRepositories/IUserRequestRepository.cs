using System.Linq.Expressions;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IRepositories;

public interface IUserRequestRepository
{
    Task<List<UserRequest>> GetAll();
    Task<UserRequest> GetById(long id);
    Task AddAsync(UserRequest entity);
    Task Update(UserRequest entity);
    Task Remove(UserRequest entity);
    Task<IEnumerable<UserRequest>> Search(Expression<Func<UserRequest, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<UserRequest, bool>> predicate);

}
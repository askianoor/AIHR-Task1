using System.Linq.Expressions;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IRepositories;

public interface IUserRequestCourseRepository
{
    Task<List<UserRequestCourse>> GetByRequestId(long userRequestId);
    Task<List<UserRequestCourse>> GetAll();
    Task<UserRequestCourse> GetById(long id);
    Task AddAsync(UserRequestCourse entity);
    Task Update(UserRequestCourse entity);
    Task Remove(UserRequestCourse entity);
    Task<IEnumerable<UserRequestCourse>> Search(Expression<Func<UserRequestCourse, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<UserRequestCourse, bool>> predicate);
}

using Task1.Domain.Enums;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IRepositories;

public interface ICourseRepository : IRepository<Course>
{
    new Task<List<Course>> GetAll();
    Task<IEnumerable<Course>> GetCoursesByCategoryId(long categoryId);
    Task<IEnumerable<Course>> GetCoursesByType(CourseType searchedValue);
}

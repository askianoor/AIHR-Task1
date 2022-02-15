using Task1.Domain.Enums;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IRepositories;

public interface ICourseRepository : IRepository<Course,long>
{
    new Task<List<Course>> GetAll();
    Task<IEnumerable<Course>> GetCoursesByCategoryId(long categoryId);
    Task<IEnumerable<Course>> GetCoursesByType(CourseType type);
    Task<IEnumerable<Course>> GetCoursesByLevel(CourseLevel level);
}

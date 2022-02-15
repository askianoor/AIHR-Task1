using Task1.Domain.Dtos.Course;
using Task1.Domain.Enums;

namespace Task1.Domain.Interfaces.IServices;

public interface ICourseService : IApplicationService<CourseRequestDto, CourseResponseDto>, IDisposable
{
    Task<IEnumerable<CourseResponseDto>> GetCoursesByCategoryId(long categoryId);
    Task<IEnumerable<CourseResponseDto>> GetCoursesByType(CourseType type);
    Task<IEnumerable<CourseResponseDto>> GetCoursesByLevel(CourseLevel level);
}
using Task1.Domain.Dtos.Course;
using Task1.Domain.Enums;

namespace Task1.Domain.Interfaces.IServices;

public interface ICourseService : IDisposable
{
    Task<IEnumerable<CourseResponseDto>> GetAll();
    Task<CourseResponseDto> GetById(long id);

    Task<CourseResponseDto> Add(CourseRequestDto course);
    Task<CourseResponseDto> Update(CourseRequestDto course);
    Task<bool> Remove(long id);

    Task<IEnumerable<CourseResponseDto>> Search(string courseName);
    Task<IEnumerable<CourseResponseDto>> GetCoursesByCategoryId(long categoryId);
    Task<IEnumerable<CourseResponseDto>> GetCoursesByType(CourseType type);
    Task<IEnumerable<CourseResponseDto>> GetCoursesByLevel(CourseLevel level);
}
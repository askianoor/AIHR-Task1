using Mapster;
using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.Course;
using Task1.Domain.Enums;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

public class CourseService : ApplicationService<Course, long, CourseRequestDto, CourseResponseDto, CourseService>, ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, ILogger<CourseService> logger)
        : base(courseRepository, unitOfWork, logger)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<CourseResponseDto>> GetCoursesByCategoryId(long categoryId)
    {
        var courses = await _courseRepository.GetCoursesByCategoryId(categoryId);
        return courses.Adapt<IEnumerable<CourseResponseDto>>();
    }

    public async Task<IEnumerable<CourseResponseDto>> GetCoursesByType(CourseType type)
    {
        var courses = await _courseRepository.GetCoursesByType(type);
        return courses.Adapt<IEnumerable<CourseResponseDto>>();
    }

    public async Task<IEnumerable<CourseResponseDto>> GetCoursesByLevel(CourseLevel level)
    {
        var courses = await _courseRepository.GetCoursesByLevel(level);
        return courses.Adapt<IEnumerable<CourseResponseDto>>();
    }
}

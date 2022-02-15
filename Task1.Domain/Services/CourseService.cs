using Mapster;
using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos;
using Task1.Domain.Dtos.Course;
using Task1.Domain.Enums;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CourseService> _logger;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, ILogger<CourseService> logger)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<CourseResponseDto>> GetAll()
    {
        var courses = await _courseRepository.GetAll();
        
        return courses.Adapt<IEnumerable<CourseResponseDto>>();
    }

    public async Task<CourseResponseDto> GetById(long id)
    {
        var course = await _courseRepository.GetById(id);
        return course.Adapt<CourseResponseDto>();
    }

    public async Task<CourseResponseDto> Add(CourseRequestDto input)
    {
        var courseExist = await _courseRepository.AnyAsync(c => c.Name == input.Name);
        if (courseExist)
        {
            throw new Exception(GlobalResource.DuplicateMsg);
        }

        var course = input.Adapt<Course>();

        try
        {
            await _courseRepository.AddAsync(course);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.AddCourseError, ex.Message);
        }

        return course.Adapt<CourseResponseDto>();
    }

    public async Task<CourseResponseDto> Update(CourseRequestDto input)
    {
        if (!await _courseRepository.AnyAsync(b => b.Id == input.Id))
        {
            throw new Exception(GlobalResource.CanNotFound);
        }

        var course = input.Adapt<Course>();

        try
        {
            await _courseRepository.Update(course);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.UpdateCourseError, ex.Message);

            throw new Exception(GlobalResource.CanNotUpdate);
        }

        return course.Adapt<CourseResponseDto>();
    }

    public async Task<bool> Remove(long id)
    {
        try
        {
            var result = await _courseRepository.GetById(id);
            var course = result.Adapt<Course>();
            await _courseRepository.Remove(course);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.RemoveCourseError, ex.Message);

            return false;
        }

        return true;
    }

    public async Task<IEnumerable<CourseResponseDto>> Search(string courseName)
    { 
        var courses = await _courseRepository.Search(row => row.Name.Contains(courseName));
        return courses.Adapt<IEnumerable<CourseResponseDto>>();
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

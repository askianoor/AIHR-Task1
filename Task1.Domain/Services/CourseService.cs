using Microsoft.Extensions.Logging;
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

    public async Task<IEnumerable<Course>> GetAll()
    {
        return await _courseRepository.GetAll();
    }

    public async Task<Course> GetById(long id)
    {
        return await _courseRepository.GetById(id);
    }

    public async Task<Course> Add(Course course)
    {
        var courseExist = await _courseRepository.AnyAsync(c => c.Name == course.Name);
        if (courseExist)
        {
            throw new Exception("DuplicateCourseMsg");
        }

        try
        {
            await _courseRepository.AddAsync(course);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError("AddCourseError: {0}", ex.Message);
        }

        return course;
    }

    public Task<Course> Update(Course course)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remove(Course course)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Course>> Search(string courseName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Course>> GetCoursesByCategoryId(long categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Course>> GetCoursesByType(string searchedValue)
    {
        throw new NotImplementedException();
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

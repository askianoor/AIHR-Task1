using Microsoft.AspNetCore.Mvc;
using Task1.Domain.Dtos.Course;
using Task1.Domain.Enums;
using Task1.Domain.Interfaces.IServices;


namespace Task1.API.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IEnumerable<CourseResponseDto>> GetAllAsync()
    {
        return await _courseService.GetAll();
    }

    [HttpGet]
    [Route("get-courses-by-level/{courseLevel}")]
    public async Task<IEnumerable<CourseResponseDto>> GetAllByLevelAsync(CourseLevel courseLevel)
    {
        return await _courseService.GetCoursesByLevel(courseLevel);
    }

    [HttpGet]
    [Route("get-courses-by-type/{courseType}")]
    public async Task<IEnumerable<CourseResponseDto>> GetAllByTypeAsync(CourseType courseType)
    {
        return await _courseService.GetCoursesByType(courseType);
    }

    [HttpGet]
    [Route("get-courses-by-category/{categoryId:long}")]
    public async Task<IEnumerable<CourseResponseDto>> GetAllByCategoryAsync(long categoryId)
    {
        return await _courseService.GetCoursesByCategoryId(categoryId);
    }

    // GET api/<CourseController>/5
    [HttpGet("{id:long}")]
    public async Task<CourseResponseDto> GetAsync(long id)
    {
        return await _courseService.GetById(id);
    }

    // POST api/<CourseController>
    [HttpPost]
    public async Task<CourseResponseDto> CreateAsync([FromBody] CourseRequestDto course)
    {
        return await _courseService.Add(course);
    }

    // PUT api/<CourseController>
    [HttpPut]
    public async Task<CourseResponseDto> UpdateAsync([FromBody] CourseRequestDto course)
    {
        return await _courseService.Update(course);
    }

    // DELETE api/<CourseController>/id
    [HttpDelete("{id:long}")]
    public async Task<bool> DeleteAsync(long id)
    {
        return await _courseService.Remove(id);
    }
}


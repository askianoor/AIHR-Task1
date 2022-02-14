using Microsoft.AspNetCore.Mvc;
using Task1.Domain.Dtos;
using Task1.Domain.Interfaces.IServices;


namespace Task1.API.Controllers;

[Route("api/[controller]")]
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

    // GET api/<CourseController>/5
    [HttpGet("{id:long}")]
    public async Task<CourseResponseDto> GetAsync(int id)
    {
        return await _courseService.GetById(id);
    }

    // POST api/<CourseController>
    [HttpPost]
    public async Task<CourseResponseDto> PostAsync([FromBody] CourseRequestDto course)
    {
        return await _courseService.Add(course);
    }

    // PUT api/<CourseController>
    [HttpPut]
    public async Task<CourseResponseDto> Put([FromBody] CourseRequestDto course)
    {
        return await _courseService.Update(course);
    }

    // DELETE api/<CourseController>/id
    [HttpDelete("{id:long}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _courseService.Remove(id);
    }
}


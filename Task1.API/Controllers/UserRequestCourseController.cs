using Microsoft.AspNetCore.Mvc;
using Task1.Domain.Dtos.UserRequestCourse;
using Task1.Domain.Interfaces.IServices;

namespace Task1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRequestCourseController : ControllerBase
{
    private readonly IUserRequestCourseService _userRequestCourseService;

    public UserRequestCourseController(IUserRequestCourseService userRequestCourseService)
    {
        _userRequestCourseService = userRequestCourseService;
    }

    [HttpGet("{requestId:long}")]
    public async Task<List<UserRequestCourseResponseDto>> GetByRequestIdAsync(long requestId)
    {
        return await _userRequestCourseService.GetByRequestId(requestId);
    }

    [HttpGet]
    [Route("get-courses-state")]
    public async Task<UserRequestCourseResponseDto> GetByRequestIdAsync([FromBody] UserRequestCourseCreateDto userRequest)
    {
        return await _userRequestCourseService.GetCourseState(userRequest);
    }

    [HttpPost]
    public async Task<UserRequestCourseResponseDto> SetCourseState([FromBody] UserRequestCourseCreateDto userRequest)
    {
        return await _userRequestCourseService.SetCourseState(userRequest);
    }


    [HttpDelete("{id:long}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRequestCourseService.RemoveCourseFromRequest(id);
    }
}


using Microsoft.AspNetCore.Mvc;
using Task1.Domain.Dtos.UserRequest;
using Task1.Domain.Interfaces.IServices;

namespace Task1.API.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class UserRequestController : ControllerBase
{
    private readonly IUserRequestService _userRequestService;

    public UserRequestController(IUserRequestService userRequestService)
    {
        _userRequestService = userRequestService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserRequestResponseDto>> GetAllAsync()
    {
        return await _userRequestService.GetAll();
    }

    [HttpGet("{id:long}")]
    public async Task<UserRequestResponseDto> GetAsync(int id)
    {
        return await _userRequestService.GetById(id);
    }

    [HttpPost]
    public async Task<UserRequestResponseDto> CreateAsync([FromBody] UserRequestRequestDto userRequest)
    {
        return await _userRequestService.Add(userRequest);
    }

    [HttpPut]
    public async Task<UserRequestResponseDto> UpdateAsync([FromBody] UserRequestRequestDto userRequest)
    {
        return await _userRequestService.Update(userRequest);
    }

    [HttpDelete("{id:long}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRequestService.Remove(id);
    }
}


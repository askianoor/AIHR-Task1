using Microsoft.AspNetCore.Mvc;
using Task1.Domain.Dtos.User;
using Task1.Domain.Interfaces.IServices;

namespace Task1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        return await _userService.GetAll();
    }

    [HttpGet("{id:long}")]
    public async Task<UserResponseDto> GetAsync(int id)
    {
        return await _userService.GetById(id);
    }

    [HttpPost]
    public async Task<UserResponseDto> PostAsync([FromBody] UserRequestDto user)
    {
        return await _userService.Add(user);
    }

    [HttpPut]
    public async Task<UserResponseDto> Put([FromBody] UserRequestDto user)
    {
        return await _userService.Update(user);
    }

    [HttpDelete("{id:long}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _userService.Remove(id);
    }
}

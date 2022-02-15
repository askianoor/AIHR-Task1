using Microsoft.AspNetCore.Mvc;
using Task1.Domain.Dtos.Tutor;
using Task1.Domain.Interfaces.IServices;

namespace Task1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TutorController : ControllerBase
{
    private readonly ITutorService _tutorService;

    public TutorController(ITutorService tutorService)
    {
        _tutorService = tutorService;
    }

    [HttpGet]
    public async Task<IEnumerable<TutorResponseDto>> GetAllAsync()
    {
        return await _tutorService.GetAll();
    }

    [HttpGet("{id:long}")]
    public async Task<TutorResponseDto> GetAsync(int id)
    {
        return await _tutorService.GetById(id);
    }

    [HttpPost]
    public async Task<TutorResponseDto> PostAsync([FromBody] TutorRequestDto tutor)
    {
        return await _tutorService.Add(tutor);
    }

    [HttpPut]
    public async Task<TutorResponseDto> Put([FromBody] TutorRequestDto tutor)
    {
        return await _tutorService.Update(tutor);
    }

    [HttpDelete("{id:long}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _tutorService.Remove(id);
    }
}


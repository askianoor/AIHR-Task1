using Microsoft.AspNetCore.Mvc;
using Task1.Domain.Dtos.Category;
using Task1.Domain.Interfaces.IServices;

namespace Task1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        return await _categoryService.GetAll();
    }

    [HttpGet("{id:long}")]
    public async Task<CategoryResponseDto> GetAsync(int id)
    {
        return await _categoryService.GetById(id);
    }

    [HttpPost]
    public async Task<CategoryResponseDto> PostAsync([FromBody] CategoryRequestDto category)
    {
        return await _categoryService.Add(category);
    }

    [HttpPut]
    public async Task<CategoryResponseDto> Put([FromBody] CategoryRequestDto category)
    {
        return await _categoryService.Update(category);
    }

    [HttpDelete("{id:long}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _categoryService.Remove(id);
    }

}
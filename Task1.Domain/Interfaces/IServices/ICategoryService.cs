using Task1.Domain.Dtos.Category;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IServices;

public interface ICategoryService : IApplicationService<Category,long,CategoryRequestDto, CategoryResponseDto,ICategoryService>, IDisposable
{
}


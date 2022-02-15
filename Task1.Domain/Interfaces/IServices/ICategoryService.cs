using Task1.Domain.Dtos.Category;

namespace Task1.Domain.Interfaces.IServices;

public interface ICategoryService : IApplicationService<CategoryRequestDto, CategoryResponseDto>, IDisposable
{
}


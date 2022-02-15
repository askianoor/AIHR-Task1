using Task1.Domain.Dtos.Category;

namespace Task1.Domain.Interfaces.IServices
{
    public interface ICategoryService : IDisposable
    {
        Task<IEnumerable<CategoryResponseDto>> GetAll();
        Task<CategoryResponseDto> GetById(long id);

        Task<CategoryResponseDto> Add(CategoryRequestDto category);
        Task<CategoryResponseDto> Update(CategoryRequestDto category);
        Task<bool> Remove(long id);
    }
}

using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.Category;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

public class CategoryService : ApplicationService<Category,long,CategoryRequestDto,CategoryResponseDto,CategoryService>, ICategoryService
{
    private CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, ILogger<CategoryService> logger) 
        : base(categoryRepository, unitOfWork, logger)
    {
    }

    public static CategoryService CreateInstance(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, ILogger<CategoryService> logger)
    {
        return new CategoryService(categoryRepository, unitOfWork, logger);
    }
}

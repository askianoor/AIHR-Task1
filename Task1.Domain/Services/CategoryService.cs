using Mapster;
using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.Category;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, ILogger<CategoryService> logger)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAll()
    {
        var categories = await _categoryRepository.GetAll();

        return categories.Adapt<IEnumerable<CategoryResponseDto>>();
    }

    public async Task<CategoryResponseDto> GetById(long id)
    {
        var category = await _categoryRepository.GetById(id);
        return category.Adapt<CategoryResponseDto>();
    }

    public async Task<CategoryResponseDto> Add(CategoryRequestDto input)
    {
        var categoryExist = await _categoryRepository.AnyAsync(c => c.Name == input.Name);
        if (categoryExist)
        {
            throw new Exception(GlobalResource.DuplicateMsg);
        }

        var category = input.Adapt<Category>();

        try
        {
            await _categoryRepository.AddAsync(category);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotAdd, ex.Message);
        }

        return category.Adapt<CategoryResponseDto>();
    }

    public async Task<CategoryResponseDto> Update(CategoryRequestDto input)
    {
        if (!await _categoryRepository.AnyAsync(b => b.Id == input.Id))
        {
            throw new Exception(GlobalResource.CanNotFound);
        }

        var category = input.Adapt<Category>();

        try
        {
            await _categoryRepository.Update(category);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotUpdate, ex.Message);

            throw new Exception(GlobalResource.CanNotUpdate);
        }

        return category.Adapt<CategoryResponseDto>();
    }

    public async Task<bool> Remove(long id)
    {
        try
        {
            var result = await _categoryRepository.GetById(id);
            var category = result.Adapt<Category>();
            await _categoryRepository.Remove(category);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotDelete, ex.Message);

            return false;
        }

        return true;
    }

    public async Task<IEnumerable<CategoryResponseDto>> Search(string categoryName)
    {
        var categories = await _categoryRepository.Search(row => row.Name.Contains(categoryName));
        return categories.Adapt<IEnumerable<CategoryResponseDto>>();
    }


    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

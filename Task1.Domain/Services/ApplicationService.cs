using Mapster;
using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

    public class ApplicationService<TEntity, TPrimaryKey, TRequest,TResponse, TService> : IApplicationService<TEntity, TPrimaryKey, TRequest, TResponse, TService>
        where TEntity : EntityName 
        where TRequest : IEntityNameDto<TPrimaryKey>
        where TResponse : class
    {
    private readonly IRepository<TEntity, TPrimaryKey> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TService> _logger;

    public ApplicationService(IRepository<TEntity, TPrimaryKey> repository, IUnitOfWork unitOfWork, ILogger<TService> logger)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public virtual async Task<IEnumerable<TResponse>> GetAll()
    {
        var categories = await _repository.GetAll();

        return categories.Adapt<IEnumerable<TResponse>>();
    }

    public virtual async Task<TResponse> GetById(TPrimaryKey id)
    {
        var entity = await _repository.GetById(id);
        return entity.Adapt<TResponse>();
    }

    public virtual async Task<TResponse> Add(TRequest input)
    {
        var entityExist = await _repository.AnyAsync(c => c.Name == input.Name);
        if (entityExist)
        {
            throw new Exception(GlobalResource.DuplicateMsg);
        }
        
        try
        {
            var entity = input.Adapt<TEntity>();
            await _repository.AddAsync(entity);
            _unitOfWork.Commit();
            return entity.Adapt<TResponse>();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotAdd, ex.Message);

            throw new Exception(GlobalResource.CanNotAdd);
        }
    }

    public virtual async Task<TResponse> Update(TRequest input)
    {

        try
        {
            var entity = await _repository.GetById(input.Id);
            await _repository.Update(entity);
            _unitOfWork.Commit();
            return entity.Adapt<TResponse>();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotUpdate, ex.Message);

            throw new Exception(GlobalResource.CanNotUpdate);
        }

    }

    public virtual async Task<bool> Remove(TPrimaryKey id)
    {

        try
        {
            var entity = await _repository.GetById(id);
            await _repository.Remove(entity);
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

    public virtual async Task<IEnumerable<TResponse>> Search(string entityName)
    {
        var categories = await _repository.Search(row => row.Name.Contains(entityName));
        return categories.Adapt<IEnumerable<TResponse>>();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
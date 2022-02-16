using Task1.Domain.Dtos;

namespace Task1.Domain.Interfaces.IServices;

public interface IApplicationService<TEntity, TPrimaryKey, TRequest, TResponse, TService>
    where TRequest: IEntityNameDto<TPrimaryKey>
    where TResponse: class
{
    Task<IEnumerable<TResponse>> GetAll();
    Task<TResponse> GetById(TPrimaryKey id);

    Task<TResponse> Add(TRequest course);
    Task<TResponse> Update(TRequest course);
    Task<bool> Remove(TPrimaryKey id);

    Task<IEnumerable<TResponse>> Search(string courseName);
}


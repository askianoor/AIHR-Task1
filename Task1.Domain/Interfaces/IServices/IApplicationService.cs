namespace Task1.Domain.Interfaces.IServices;

public interface IApplicationService<TEntity, TPrimaryKey, TRequest, TResponse, TService>
    where TRequest: class 
    where TResponse: class
{
    Task<IEnumerable<TResponse>> GetAll();
    Task<TResponse> GetById(long id);

    Task<TResponse> Add(TRequest course);
    Task<TResponse> Update(TRequest course);
    Task<bool> Remove(long id);

    Task<IEnumerable<TResponse>> Search(string courseName);
}


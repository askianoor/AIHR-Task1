namespace Task1.Domain.Interfaces.IServices;

public interface IApplicationService<in TRequest, TResponse>
{
    Task<IEnumerable<TResponse>> GetAll();
    Task<TResponse> GetById(long id);

    Task<TResponse> Add(TRequest course);
    Task<TResponse> Update(TRequest course);
    Task<bool> Remove(long id);

    Task<IEnumerable<TResponse>> Search(string courseName);
}


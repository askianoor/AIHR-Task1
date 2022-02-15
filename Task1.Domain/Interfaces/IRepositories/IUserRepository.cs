using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IRepositories;

public interface IUserRepository : IRepository<User, long>
{

}
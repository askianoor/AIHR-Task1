using Task1.Domain.Dtos.User;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IServices;

public interface IUserService : IApplicationService<User, long, UserRequestDto, UserResponseDto, ITutorService>, IDisposable
{

}


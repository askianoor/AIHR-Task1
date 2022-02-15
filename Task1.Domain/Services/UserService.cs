using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.User;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;
using Task1.Domain.Services;

public class UserService : ApplicationService<User, long, UserRequestDto, UserResponseDto, UserService>, IUserService
{
    private UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<UserService> logger)
        : base(userRepository, unitOfWork, logger)
    {
    }

    internal static UserService CreateInstance(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<UserService> logger)
    {
        return new UserService(userRepository, unitOfWork, logger);
    }
}

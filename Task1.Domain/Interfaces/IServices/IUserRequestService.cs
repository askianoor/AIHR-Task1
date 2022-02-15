using Task1.Domain.Dtos.UserRequest;

namespace Task1.Domain.Interfaces.IServices;

public interface IUserRequestService
{
    Task<IEnumerable<UserRequestResponseDto>> GetAll();
    Task<UserRequestResponseDto> GetById(long id);

    Task<UserRequestResponseDto> Add(UserRequestRequestDto course);
    Task<UserRequestResponseDto> Update(UserRequestRequestDto course);
    Task<bool> Remove(long id);
}

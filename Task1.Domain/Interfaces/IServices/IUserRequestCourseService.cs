using Task1.Domain.Dtos.UserRequestCourse;

namespace Task1.Domain.Interfaces.IServices;

public interface IUserRequestCourseService
{
    Task<List<UserRequestCourseResponseDto>> GetByRequestId(long requestId);

    Task<bool> RemoveCourseFromRequest(long userRequestCourseId);

    Task<UserRequestCourseResponseDto> GetCourseState(UserRequestCourseRequestDto userRequestCourseRequest);
    Task<UserRequestCourseResponseDto> SetCourseState(UserRequestCourseCreateDto userRequestCourseCreate);
}

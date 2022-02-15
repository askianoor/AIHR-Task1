using Task1.Domain.Dtos.UserRequestCourse;
using Task1.Domain.Enums;

namespace Task1.Domain.Dtos.UserRequest;

public class UserRequestResponseDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestState RequestState { get; set; }
    public int TotalHourPerWeek { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    public long UserName { get; set; }

    public ICollection<UserRequestCourseResponseDto> UserRequestCourses { get; set; }
}

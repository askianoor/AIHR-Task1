using Mapster;

namespace Task1.Domain.Dtos.UserRequestCourse;

[AdaptTo(typeof(Models.UserRequestCourse))]
public class UserRequestCourseRequestDto
{
    public long UserRequestId { get; set; }
    public long CourseId { get; set; }
}

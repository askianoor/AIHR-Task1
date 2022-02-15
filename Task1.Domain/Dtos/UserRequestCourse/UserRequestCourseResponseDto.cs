using Mapster;
using Task1.Domain.Enums;

namespace Task1.Domain.Dtos.UserRequestCourse;

[AdaptTwoWays(typeof(Models.UserRequestCourse))]
public class UserRequestCourseResponseDto
{
    public int CompletionHours { get; set; }
    public CourseState CourseState { get; set; }

    public long CourseId { get; set; }
    public string CourseName { get; set; }

    public long UserRequestId { get; set; }
}

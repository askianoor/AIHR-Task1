using Mapster;
using Task1.Domain.Enums;

namespace Task1.Domain.Dtos.UserRequestCourse;


[AdaptTo(typeof(Models.UserRequestCourse))]
public class UserRequestCourseCreateDto : UserRequestCourseRequestDto
{
    public long? Id { get; set; }
    public int CompletionHours { get; set; }
    public CourseState CourseState { get; set; }
}

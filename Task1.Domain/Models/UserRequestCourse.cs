using Task1.Domain.Enums;

namespace Task1.Domain.Models;

public class UserRequestCourse : Entity
{
    public int CompletionHours { get; set; } = 0;
    public CourseState CourseState { get; set; } = CourseState.ToDo;

    public long CourseId { get; set; }
    public Course? Course { get; set; }
    
    public long UserRequestId { get; set; }
    public UserRequest? UserRequest { get; set; }
}

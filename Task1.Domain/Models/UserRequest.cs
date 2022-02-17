using Task1.Domain.Enums;

namespace Task1.Domain.Models;

public class UserRequest: Entity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestState RequestState { get; set; }
    public int TotalHourPerWeek { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime? ModificationDate { get; set; } = null;

    public long UserId { get; set; }
    public User? User { get; set; }

    public ICollection<UserRequestCourse> UserRequestCourses { get; set; }
}


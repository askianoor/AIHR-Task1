using Task1.Domain.Enums;

namespace Task1.Domain.Dtos.UserRequest;

public class UserRequestRequestDto
{
    public long? Id { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestState RequestState { get; set; }
    public long UserId { get; set; }
    public List<long> CourseIds { get; set; }
}


using Task1.Domain.Enums;

namespace Task1.Domain.Models;

public class Course : Entity
{
    public string Name { get; set; }
    public int Duration { get; set; }
    public CourseType Type { get; set; }
    public bool IsActive { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }

    public long TutorId { get; set; }
    public Tutor Tutor { get; set; }
}


using Task1.Domain.Enums;

namespace Task1.Domain.Dtos.Course;

public class CourseResponseDto
{
    public string? Name { get; set; }

    public int Duration { get; set; }
    public CourseType Type { get; set; }
    public CourseLevel Level { get; set; }
    public bool IsActive { get; set; }

    public long CategoryId { get; set; }
    public string? CategoryName { get; set; }

    public long TutorId { get; set; }
    public string? TutorName { get; set; }
}
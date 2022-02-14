using System.ComponentModel.DataAnnotations.Schema;
using Task1.Domain.Enums;

namespace Task1.Domain.Models;

[Table("Courses")]
public class Course : Entity
{
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    public int Duration { get; set; }
    public CourseType Type { get; set; }
    public CourseLevel Level { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public bool IsActive { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }

    public long TutorId { get; set; }
    public Tutor Tutor { get; set; }
}


namespace Task1.Domain.Models;

public class Category : EntityName
{
    public string Description { get; set; }

    public ICollection<Course> Courses { get; set; }
}

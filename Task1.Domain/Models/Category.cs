namespace Task1.Domain.Models;

public class Category : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Course> Courses { get; set; }
}

namespace Task1.Domain.Dtos.Category;

public class CategoryRequestDto: IEntityNameDto<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


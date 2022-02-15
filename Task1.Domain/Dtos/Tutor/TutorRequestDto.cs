namespace Task1.Domain.Dtos.Tutor;

public class TutorRequestDto: IEntityNameDto<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


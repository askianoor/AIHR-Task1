namespace Task1.Domain.Dtos;

public interface IEntityDto<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}

public interface IEntityNameDto<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
    string Name { get; set; }
}
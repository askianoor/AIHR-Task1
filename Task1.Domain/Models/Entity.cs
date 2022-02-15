using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Domain.Models;

public abstract class Entity
{
    [Key]
    public long Id { get; set; }
}

public abstract class EntityName
{
    [Key]
    public long Id { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
}
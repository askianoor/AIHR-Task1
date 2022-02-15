namespace Task1.Domain.Dtos.User;

public class UserResponseDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surename { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; } = true;
}


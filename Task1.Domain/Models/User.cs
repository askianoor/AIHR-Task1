namespace Task1.Domain.Models;

public class User : EntityName
{
    public string Surename { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<UserRequest> UserRequests { get; set; }
}
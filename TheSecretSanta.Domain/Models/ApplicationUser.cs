namespace TheSecretSanta.Domain.Models;

public class ApplicationUser
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid ApiKey { get; set; }
}

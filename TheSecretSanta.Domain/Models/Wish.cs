namespace TheSecretSanta.Domain.Models;

public class Wish
{
    public Guid Id { get; set; }
    public Dictionary<string, object> Fields { get; set; } = null!;
    public Guid UserId { get; set; }
}

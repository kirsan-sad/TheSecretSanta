namespace TheSecretSanta.Infrastructure.Entities;

public class ApplicationUserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid ApiKey { get; set; }

    public List<WishEntity> Wishes { get; set; } = null!;
}

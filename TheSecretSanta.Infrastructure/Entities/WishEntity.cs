namespace TheSecretSanta.Infrastructure.Entities;

public class WishEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Dictionary<string, object> Fields { get; set; } = null!;

    public Guid UserId { get; set; } = Guid.Empty;
    public ApplicationUserEntity ApplicationUser { get; set; } = null!;
}

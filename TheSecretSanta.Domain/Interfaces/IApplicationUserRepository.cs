using TheSecretSanta.Domain.Models;

namespace TheSecretSanta.Domain.Interfaces;

public interface IApplicationUserRepository
{
    Task<ApplicationUser> GetApplicationUserByApiKey(Guid id);
}

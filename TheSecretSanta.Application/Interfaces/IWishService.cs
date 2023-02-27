using TheSecretSanta.Domain.Models;

namespace TheSecretSanta.Application.Interfaces;

public interface IWishService
{
    Task<IEnumerable<Wish>> GetAllAsync(Guid userId, int take, int skip);
    Task<IEnumerable<Wish>> GetBySearchTermAsync(Guid userId, string term, int take, int skip);
    Task<Wish> GetWishByIdAsync(Guid id);
    Task<Wish> CreateAsync(Dictionary<string, object> wish, Guid userId);
    Task<Wish> UpdateAsync(Dictionary<string, object> wish, Guid id);
    Task<Guid> DeleteAsync(Guid id);
}

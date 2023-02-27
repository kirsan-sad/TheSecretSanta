using TheSecretSanta.Domain.Models;

namespace TheSecretSanta.Domain.Interfaces;

public interface IWishRepository
{
    Task<IEnumerable<Wish>> GetAllWishes(Guid userId, int take, int skip);
    Task<IEnumerable<Wish>> GetWishesBySearchTerm(Guid userId, string term, int take, int skip);
    Task<Wish> GetWishById(Guid id);
    Task AddWish(Wish wish);
    Task UpdateWish(Wish wish);
    Task DeleteWish(Wish wish);
}

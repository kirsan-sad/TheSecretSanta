using TheSecretSanta.Application.Interfaces;
using TheSecretSanta.Domain.Exeptions;
using TheSecretSanta.Domain.Interfaces;
using TheSecretSanta.Domain.Models;

namespace TheSecretSanta.Application.Services;

public class WishService : IWishService
{
    private readonly IWishRepository _repo;

    public WishService(IWishRepository repo)
    {
        _repo = repo;
    }
    public async Task<Wish> CreateAsync(Dictionary<string, object> fields, Guid userId)
    {
        if(fields.Count == 0) throw new BadRequestException($"The wish fields are empty");

        Wish newWish = new()
        {
            Id = Guid.NewGuid(),
            Fields = fields,
            UserId = userId
        };

        await _repo.AddWish(newWish);

        return newWish;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        var wish = await GetWishByIdAsync(id);

        await _repo.DeleteWish(wish);

        return id;
    }

    public async Task<IEnumerable<Wish>> GetAllAsync(Guid userId, int take, int skip)
    {
        return await _repo.GetAllWishes(userId, take, skip);
    }

    public async Task<IEnumerable<Wish>> GetBySearchTermAsync(Guid userId, string searchTerm, int take, int skip)
    {
        return await _repo.GetWishesBySearchTerm(userId, searchTerm, take, skip);
    }

    public async Task<Wish> GetWishByIdAsync(Guid id)
    {
        var wish = await _repo.GetWishById(id) 
            ?? throw new NotFoundException($"Wish by id {id} not found");

        return wish;
    }

    public async Task<Wish> UpdateAsync(Dictionary<string, object> updatedFields, Guid id)
    {
        if (updatedFields.Count == 0) throw new BadRequestException($"The wish fields are empty");

        var wishForUpdate = await _repo.GetWishById(id) 
            ?? throw new NotFoundException($"Wish by id {id} not found"); ;

        wishForUpdate.Fields = updatedFields;

        await _repo.UpdateWish(wishForUpdate);

        return wishForUpdate;
    }
}

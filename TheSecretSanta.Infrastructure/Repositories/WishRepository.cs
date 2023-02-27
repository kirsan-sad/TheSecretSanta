using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheSecretSanta.Domain.Interfaces;
using TheSecretSanta.Domain.Models;
using TheSecretSanta.Infrastructure.Data;
using TheSecretSanta.Infrastructure.Entities;

namespace TheSecretSanta.Infrastructure.Repositories;

public class WishRepository : BaseRepository<WishEntity>, IWishRepository
{
    private readonly IMapper _mapper;
    private readonly InMemoryDbContext _context;

    public WishRepository(InMemoryDbContext context, IMapper mapper) :
        base(context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task AddWish(Wish wish)
    {
        Create(_mapper.Map<WishEntity>(wish));
        await SaveAsync();
    }

    public async Task DeleteWish(Wish wish)
    {
        Delete(_mapper.Map<WishEntity>(wish));
        await SaveAsync();
    }

    public async Task<IEnumerable<Wish>> GetAllWishes(Guid userId, int take, int skip) =>
        _mapper.Map<List<Wish>>(await FindByCondition(w => w.UserId == userId)
            .Take(take)
            .Skip(skip)
            .AsNoTracking()
            .ToListAsync());

    public async Task<Wish> GetWishById(Guid id) =>
         _mapper.Map<Wish>(await FindByCondition(w => w.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync());

    public async Task<IEnumerable<Wish>> GetWishesBySearchTerm(Guid userId, string term, int take, int skip)
    {
        Expression<Func<WishEntity, bool>> filter = w => w.UserId == userId;
        var wishes = await FindByCondition(filter).AsNoTracking().ToListAsync();
        var result = wishes.Where(wish => wish.Fields.Any(field => field.Value != null && field.Value.ToString().Contains(term)));

        return _mapper.Map<List<Wish>>(result.Take(take).Skip(skip));
    }

    public async Task UpdateWish(Wish wish)
    {
        Update(_mapper.Map<WishEntity>(wish));
        await SaveAsync();
    }
}

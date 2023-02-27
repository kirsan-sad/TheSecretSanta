using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheSecretSanta.Domain.Interfaces;
using TheSecretSanta.Domain.Models;
using TheSecretSanta.Infrastructure.Data;
using TheSecretSanta.Infrastructure.Entities;

namespace TheSecretSanta.Infrastructure.Repositories;

public class ApplicationUserRepository : BaseRepository<ApplicationUserEntity>, IApplicationUserRepository
{
    private readonly IMapper _mapper;

    public ApplicationUserRepository(InMemoryDbContext context, IMapper mapper)
        :base(context)
    {
        _mapper = mapper;
    }

    public async Task<ApplicationUser> GetApplicationUserByApiKey(Guid id) =>
        _mapper.Map<ApplicationUser>(await FindByCondition(u => u.ApiKey == id).FirstOrDefaultAsync());
}

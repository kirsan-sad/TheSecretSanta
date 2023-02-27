using AutoMapper;
using TheSecretSanta.Domain.Models;
using TheSecretSanta.Infrastructure.Entities;

namespace TheSecretSanta.Infrastructure.Mappings;

public class WishMapping : Profile
{
    public WishMapping()
    {
        CreateMap<WishEntity, Wish>();
        CreateMap<Wish, WishEntity>();
    }
}

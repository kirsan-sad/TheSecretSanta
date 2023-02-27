using AutoMapper;
using TheSecretSanta.Domain.Models;
using TheSecretSanta.Infrastructure.Entities;

namespace TheSecretSanta.Infrastructure.Mappings;

public class ApplicationUserMapping : Profile
{
    public ApplicationUserMapping()
    {
        CreateMap<ApplicationUserEntity, ApplicationUser>();
        CreateMap<ApplicationUser, ApplicationUserEntity>();
    }
}

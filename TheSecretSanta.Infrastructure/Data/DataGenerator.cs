using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheSecretSanta.Infrastructure.Entities;

namespace TheSecretSanta.Infrastructure.Data;

public class DataGenerator
{
    public static async void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new InMemoryDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<InMemoryDbContext>>()))
        {
            if (context.Wishes.Any())
            {
                return;
            }

            var user = new ApplicationUserEntity()
            {
                Id = Guid.NewGuid(),
                Name = "ReactApp",
                ApiKey = Guid.Parse("6A363E9E-A6B8-45E0-A100-3ED7F362FE53")
            };

            if (!context.ApplicationUsers.Any())
            {
                context.ApplicationUsers.Add(user);
            }

            context.Wishes.AddRange(
                new WishEntity
                {
                    Id = Guid.NewGuid(),
                    Fields = new Dictionary<string, object>()
                    {
                        {"wish", "A tech enthusiast wishes for the latest gadget"},
                        {"isAdult", true},
                        {"category", "Gadget"},
                        {"isCompleted", false},
                        {"date", "2023-12-25"},
                        {"wishNumber", 1 },
                    },
                    UserId = (Guid)(user.Id)
                },
                new WishEntity
                {
                    Id = Guid.NewGuid(),
                    Fields = new Dictionary<string, object>()
                    {
                        {"wish", "An art lover dreams of receiving a painting kit"},
                        {"isAdult", false},
                        {"category", "Hobby"},
                        {"isCompleted", false},
                        {"date", "2023-12-25"},
                        {"wishNumber", 2 },
                    },
                    UserId = (Guid)(user.Id)
                },
                new WishEntity
                {
                    Id = Guid.NewGuid(),
                    Fields = new Dictionary<string, object>()
                    {
                        {"wish", "A bookworm would love to get a signed copy of their favorite author's new book"},
                        {"isAdult", false},
                        {"category", "Hobby"},
                        {"isCompleted", true},
                        {"date", "2023-12-24"},
                        {"wishNumber", 3 },
                    },
                    UserId = (Guid)(user.Id)
                });

            context.SaveChanges();
        }
    }
}

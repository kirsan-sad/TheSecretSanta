using Microsoft.EntityFrameworkCore;
using TheSecretSanta.Infrastructure.Entities;
using TheSecretSanta.Infrastructure.Mappings;

namespace TheSecretSanta.Infrastructure.Data;

public class InMemoryDbContext : DbContext
{
    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
    {
    }

    public DbSet<WishEntity> Wishes { get; set; }
    public DbSet<ApplicationUserEntity> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WishEntity>()
            .HasOne(w => w.ApplicationUser)
            .WithMany(a => a.Wishes)
            .HasForeignKey(s => s.UserId);

        modelBuilder.Entity<WishEntity>()
            .Property(w => w.Fields)
            .HasConversion(new DictionaryConverter());
    }
}

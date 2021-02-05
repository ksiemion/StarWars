using Microsoft.EntityFrameworkCore;
using StarWars.Core.Domain;

namespace StarWars.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>().HasKey(x => x.ID);
            modelBuilder.Entity<Episode>().HasKey(x => x.ID);
            modelBuilder.Entity<Planet>().HasKey(x => x.ID);

            modelBuilder.Entity<Character>()
                .HasMany(t => t.Episodes)
                .WithMany(t => t.Characters);

            modelBuilder.Entity<Character>()
                .HasMany(u => u.Friends)
                .WithMany(u => u.FriendOf);

            modelBuilder.Entity<Character>()
               .HasOne(p => p.Planet)
               .WithMany(c => c.Characters);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Data
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
            modelBuilder.Entity<Character>()
                .HasMany(t => t.Episodes)
                .WithMany(t => t.Characters);

            modelBuilder.Entity<Character>()
                .HasMany(u => u.Friends)
                .WithMany(u => u.FriendOf);

        }
    }
}

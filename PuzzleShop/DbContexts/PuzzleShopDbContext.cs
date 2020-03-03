using Microsoft.EntityFrameworkCore;
using PuzzleShop.Entities;
// ReSharper disable All

namespace PuzzleShop.DbContexts
{
    public sealed class PuzzleShopDbContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Puzzle> Puzzles { get; set; }
        public DbSet<PuzzleType> PuzzleTypes { get; set; }
        public DbSet<PlasticColor> PlasticColors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<DifficultyLevel> Levels { get; set; }

        public PuzzleShopDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
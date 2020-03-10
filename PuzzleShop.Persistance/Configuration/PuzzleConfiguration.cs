using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class PuzzlesConfiguration : IEntityTypeConfiguration<Puzzle>
    {
        public void Configure(EntityTypeBuilder<Puzzle> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IsWcaPuzzle).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);
            
            builder
                .HasOne(p => p.Manufacturer)
                .WithMany(m => m.Puzzles)
                .HasForeignKey(p => p.ManufacturerId)
                .IsRequired();

            builder
                .HasOne(p => p.PuzzleType)
                .WithMany(t => t.Puzzles)
                .HasForeignKey(p => p.PuzzleTypeId)
                .IsRequired();

            builder
                .HasOne(p => p.Color)
                .WithMany(c => c.Puzzles)
                .HasForeignKey(p => p.ColorId)
                .IsRequired();

            builder
                .HasOne(p => p.MaterialType)
                .WithMany(m => m.Puzzles)
                .HasForeignKey(p => p.MaterialTypeId)
                .IsRequired();

            builder
                .HasOne(p => p.DifficultyLevel)
                .WithMany(d => d.Puzzles)
                .HasForeignKey(p => p.DifficultyLevelId)
                .IsRequired();
        }
    }
}
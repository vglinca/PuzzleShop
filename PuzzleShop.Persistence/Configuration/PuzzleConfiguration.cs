using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Core.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class PuzzlesConfiguration : IEntityTypeConfiguration<Puzzle>
    {
        public void Configure(EntityTypeBuilder<Puzzle> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IsMagnetic).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder
                .HasOne(p => p.Manufacturer)
                .WithMany(m => m.Puzzles)
                .HasForeignKey(p => p.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne(p => p.PuzzleType)
                .WithMany(t => t.Puzzles)
                .HasForeignKey(p => p.PuzzleTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne(p => p.Color)
                .WithMany(c => c.Puzzles)
                .HasForeignKey(p => p.ColorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne(p => p.MaterialType)
                .WithMany(m => m.Puzzles)
                .HasForeignKey(p => p.MaterialTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasMany(p => p.Images)
                .WithOne(i => i.Puzzle)
                .HasForeignKey(i => i.PuzzleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Core.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class PuzzleTypeConfiguration : IEntityTypeConfiguration<PuzzleType>
    {
        public void Configure(EntityTypeBuilder<PuzzleType> builder)
        {
            builder.Property(t => t.TypeName).IsRequired();

            builder
                .HasOne(p => p.DifficultyLevel)
                .WithMany(d => d.PuzzlesTypes)
                .HasForeignKey(p => p.DifficultyLevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
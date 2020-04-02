using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class DifficultyLevelConfiguration : IEntityTypeConfiguration<DifficultyLevel>
    {
        public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
        {
            builder.Ignore(p => p.Id);
            builder.Property(p => p.DifficultyLevelId)
                .HasConversion<long>();
            builder.HasKey(p => p.DifficultyLevelId);
        }
    }
}
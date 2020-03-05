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
            builder.Property(d => d.LevelName).IsRequired();
        }
    }
}
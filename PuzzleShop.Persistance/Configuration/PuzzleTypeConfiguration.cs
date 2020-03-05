using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class PuzzleTypeConfiguration : IEntityTypeConfiguration<PuzzleType>
    {
        public void Configure(EntityTypeBuilder<PuzzleType> builder)
        {
            builder.Property(t => t.TypeName).IsRequired();
        }
    }
}
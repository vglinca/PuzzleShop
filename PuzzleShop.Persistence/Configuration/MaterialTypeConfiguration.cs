using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Core.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class MaterialTypeConfiguration : IEntityTypeConfiguration<MaterialType>
    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            builder.Property(m => m.Title).IsRequired();
        }
    }
}
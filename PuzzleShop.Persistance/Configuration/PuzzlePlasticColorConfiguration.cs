using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class PuzzlePlasticColorConfiguration : IEntityTypeConfiguration<PlasticColor>
    {
        public void Configure(EntityTypeBuilder<PlasticColor> builder)
        {
            builder.Property(c => c.Color).IsRequired();
        }
    }
}
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Persistance.Configuration
{
    public class ManufacturersConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(p => p.Description)
                .HasMaxLength(1500);
        }
    }
}
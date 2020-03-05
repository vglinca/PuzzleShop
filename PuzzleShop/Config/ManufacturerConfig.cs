using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Entities;

namespace PuzzleShop.Config
{
    public class ManufacturerConfig : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}
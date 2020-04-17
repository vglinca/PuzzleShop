using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.FileName).IsRequired();
            //builder.HasOne(i => i.Puzzle)
            //    .WithMany(p => p.Images)
            //    .HasForeignKey(i => i.PuzzleId)
            //    .IsRequired();
        }
    }
}
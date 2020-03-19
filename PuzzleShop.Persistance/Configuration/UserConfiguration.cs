using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.UserRole)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.Email).IsRequired();
        }
    }
}
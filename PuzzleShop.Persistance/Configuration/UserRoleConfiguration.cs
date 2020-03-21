// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using PuzzleShop.Domain.Entities;
// // ReSharper disable All
//
// namespace PuzzleShop.Persistance.Configuration
// {
//     public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
//     {
//         public void Configure(EntityTypeBuilder<UserRole> builder)
//         {
//             builder
//                 .HasMany(r => r.Users)
//                 .WithOne(u => u.UserRole)
//                 .HasForeignKey(u => u.UserRoleId);
//
//             builder.Property(r => r.Title)
//                 .HasMaxLength(25)
//                 .IsRequired();
//         }
//     }
// }
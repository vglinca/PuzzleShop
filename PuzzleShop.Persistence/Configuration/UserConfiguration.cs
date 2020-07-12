﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Core.Domain.Auth;

// ReSharper disable All

namespace PuzzleShop.Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Email)
                .IsUnique();
            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Email).IsRequired();
        }
    }
}
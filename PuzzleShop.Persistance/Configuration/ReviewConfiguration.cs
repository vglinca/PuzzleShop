using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Persistance.Configuration
{
	public class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.HasOne(r => r.Puzzle)
				.WithMany(p => p.Reviews)
				.HasForeignKey(r => r.PuzzleId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.Property(r => r.ReviewBody)
				.HasMaxLength(1500);
			builder.Property(r => r.ReviewTitle)
				.HasMaxLength(100);
		}
	}
}

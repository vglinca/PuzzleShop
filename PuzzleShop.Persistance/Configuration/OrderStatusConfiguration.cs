using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Persistance.Configuration
{
	public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
	{
		public void Configure(EntityTypeBuilder<OrderStatus> builder)
		{

			builder.Ignore(p => p.Id);
			builder
				.Property(os => os.OrderStatusId)
				.HasConversion<long>();
			builder.HasKey(os => os.OrderStatusId);
		}
	}
}

﻿// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Domain.Entities.Auth;
using PuzzleShop.Persistance.Helpers;
using PuzzleShop.Persistance.Schema;

namespace PuzzleShop.Persistance.DbContext
{
	public sealed class PuzzleShopContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
	{
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Puzzle> Puzzles { get; set; }
		public DbSet<PuzzleType> PuzzleTypes { get; set; }
		public DbSet<Color> Colors { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
		public DbSet<MaterialType> MaterialTypes { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderStatus> OrdeStatuses { get; set; }
		public DbSet<Review> Reviews { get; set; }

		public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
			builder.AddFilter((category, lvl) => category == DbLoggerCategory.Database.Command.Name
												 && lvl == LogLevel.Information)
				.AddProvider(new LoggerProvider()));

		public PuzzleShopContext(DbContextOptions options) : base(options){}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseLoggerFactory(MyLoggerFactory)
				.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => !string.IsNullOrWhiteSpace(t.Namespace))
				.Where(t => t.BaseType != null && t.BaseType.IsInterface
											   && t.BaseType.IsGenericType
											   && t.BaseType.GetGenericTypeDefinition() ==
											   typeof(IEntityTypeConfiguration<>));

			foreach (var type in typesToRegister)
			{
				dynamic configInstance = Activator.CreateInstance(type);
				modelBuilder.ApplyConfiguration(configInstance);
			}

			ApplyIdentityMapConfig(modelBuilder);
			SeedData(modelBuilder);
		}

		private void SeedData(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MaterialType>().HasData(
				new MaterialType { Id = 1, Title = "Plastic" });

			modelBuilder.Entity<PuzzleType>().HasData(
				new PuzzleType { Id = 1, TypeName = "3x3x3", IsRubicsCube = true, IsWca = true, DifficultyLevelId = DifficultyLevelId.Medium },
				new PuzzleType { Id = 2, TypeName = "4x4x4", IsRubicsCube = true, IsWca = true, DifficultyLevelId = DifficultyLevelId.Medium },
				new PuzzleType { Id = 3, TypeName = "5x5x5", IsRubicsCube = true, IsWca = true, DifficultyLevelId = DifficultyLevelId.Medium },
				new PuzzleType { Id = 4, TypeName = "6x6x6", IsRubicsCube = true, IsWca = true, DifficultyLevelId = DifficultyLevelId.High },
				new PuzzleType { Id = 5, TypeName = "skewb", IsRubicsCube = false, IsWca = true, DifficultyLevelId = DifficultyLevelId.Low },
				new PuzzleType { Id = 6, TypeName = "square-1", IsRubicsCube = false, IsWca = true, DifficultyLevelId = DifficultyLevelId.Medium },
				new PuzzleType { Id = 7, TypeName = "Megaminx", IsRubicsCube = false, IsWca = true, DifficultyLevelId = DifficultyLevelId.Medium });

			modelBuilder.Entity<Color>().HasData(
				new Color { Id = 1, Title = "White" },
				new Color { Id = 2, Title = "Black" },
				new Color { Id = 3, Title = "Stickerless" },
				new Color { Id = 4, Title = "Pink" });

			modelBuilder.Entity<DifficultyLevel>()
				.Ignore(dl => dl.Id)
				.HasData(
					Enum.GetValues(typeof(DifficultyLevelId))
					.Cast<DifficultyLevelId>()
					.Select(dl => new DifficultyLevel
					{
						DifficultyLevelId = dl,
						Title = dl.ToString()
					})
				);

			modelBuilder.Entity<Manufacturer>().HasData(
				new Manufacturer { Id = 1, Name = "Gan" },
				new Manufacturer { Id = 2, Name = "MoYu" },
				new Manufacturer { Id = 3, Name = "QiYi" },
				new Manufacturer { Id = 4, Name = "Rubics" },
				new Manufacturer { Id = 5, Name = "DaYan" },
				new Manufacturer { Id = 6, Name = "YJ" });

			modelBuilder.Entity<Puzzle>().HasData(
				new Puzzle
				{
					Id = 1,
					Name = "Gan 356 X",
					Price = 45.0m,
					IsMagnetic = true,
					Weight = 350,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 1,
					PuzzleTypeId = 1,
					ColorId = 3,
					MaterialTypeId = 1,
				},
				new Puzzle
				{
					Id = 2,
					Name = "Gan 356 XS",
					Price = 60.0m,
					IsMagnetic = true,
					Weight = 330,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 1,
					PuzzleTypeId = 1,
					ColorId = 1,
					MaterialTypeId = 1,
				},
				new Puzzle
				{
					Id = 3,
					Name = "MoYu Weilong GTS 3M",
					Price = 30.0m,
					IsMagnetic = true,
					Weight = 345,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 2,
					PuzzleTypeId = 1,
					ColorId = 3,
					MaterialTypeId = 1,
				},
				new Puzzle
				{
					Id = 4,
					Name = "DaYan 7 TengYun",
					Price = 25.0m,
					IsMagnetic = true,
					Weight = 334,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 5,
					PuzzleTypeId = 1,
					ColorId = 3,
					MaterialTypeId = 1,
				},
				new Puzzle
				{
					Id = 5,
					Name = "Gan 354 M",
					Price = 34.0m,
					IsMagnetic = true,
					Weight = 290,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 1,
					PuzzleTypeId = 1,
					ColorId = 3,
					MaterialTypeId = 1,
				},
				new Puzzle
				{
					Id = 6,
					Name = "QiYi Valk Power M",
					Price = 17.0m,
					IsMagnetic = true,
					Weight = 330,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 3,
					PuzzleTypeId = 1,
					ColorId = 1,
					MaterialTypeId = 1,
				},
				new Puzzle
				{
					Id = 7,
					Name = "QiYi WuQue Mini M",
					Price = 24.0m,
					IsMagnetic = true,
					Weight = 330,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 3,
					PuzzleTypeId = 2,
					ColorId = 3,
					MaterialTypeId = 1,
				},
				new Puzzle
				{
					Id = 8,
					Name = "QiYi X-Man Skewb Wingy M",
					Price = 12.0m,
					IsMagnetic = true,
					Weight = 220,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 3,
					PuzzleTypeId = 5,
					ColorId = 3,
					MaterialTypeId = 1
				},
				new Puzzle
				{
					Id = 9,
					Name = "MoYu Skewb AoYan M",
					Price = 22.0m,
					IsMagnetic = true,
					Weight = 220,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 2,
					PuzzleTypeId = 5,
					ColorId = 2,
					MaterialTypeId = 1
				},
				new Puzzle
				{
					Id = 10,
					Name = "MoYu Square-1 MeiLong",
					Price = 10.0m,
					IsMagnetic = true,
					Weight = 220,
					DateWhenAdded = DateTimeOffset.Now,
					ManufacturerId = 2,
					PuzzleTypeId = 6,
					ColorId = 2,
					MaterialTypeId = 1
				});

			modelBuilder.Entity<OrderStatus>()
				.Ignore(s => s.Id)
				.HasData(
					Enum.GetValues(typeof(OrderStatusId))
					.Cast<OrderStatusId>()
					.Select(o => new OrderStatus
					{
						OrderStatusId = o,
						Name = o.ToString()
					})
				);
		}

		private void ApplyIdentityMapConfig(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Role>().ToTable("Roles", SchemaConsts.Auth);
			modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConsts.Auth);
			modelBuilder.Entity<User>().ToTable("Users", SchemaConsts.Auth);
			modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConsts.Auth);
			modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConsts.Auth);
			modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConsts.Auth);
			modelBuilder.Entity<UserToken>().ToTable("UserTokens", SchemaConsts.Auth);
		}
	}
}
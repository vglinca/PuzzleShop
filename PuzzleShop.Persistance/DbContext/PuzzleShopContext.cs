// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.Helpers;

namespace PuzzleShop.Persistance.DbContext
{
    public sealed class PuzzleShopContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Puzzle> Puzzles { get; set; }
        public DbSet<PuzzleType> PuzzleTypes { get; set; }
        public DbSet<Color> PlasticColors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<DifficultyLevel> Levels { get; set; }
        
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
            builder.AddFilter((category, lvl) => category == DbLoggerCategory.Database.Command.Name
                                                 && lvl == LogLevel.Information)
                .AddProvider(new LoggerProvider()));

        public PuzzleShopContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<PuzzleType>().HasData(
                new PuzzleType
                {
                    Id = 1, TypeName = "3x3x3"
                },
                new PuzzleType
                {
                    Id = 2, TypeName = "4x4x4"
                },
                new PuzzleType
                {
                    Id = 3, TypeName = "5x5x5"
                });
            modelBuilder.Entity<Color>().HasData(
                new Color
                {
                    Id = 1, Title = "White"
                },
                new Color
                {
                    Id = 2, Title = "Black"
                },
                new Color
                {
                    Id = 3, Title = "Stickerless"
                });
            modelBuilder.Entity<DifficultyLevel>().HasData(
                new DifficultyLevel
                {
                    Id = 1, Title = "Low"
                },
                new DifficultyLevel
                {
                    Id = 2, Title = "Middle"
                },
                new DifficultyLevel
                {
                    Id = 3, Title = "High"
                });
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer
                {
                    Id = 1, Name = "Gan"
                },
                new Manufacturer
                {
                    Id = 2, Name = "MoYu"
                },
                new Manufacturer
                {
                    Id = 3, Name = "QiYi"
                },
                new Manufacturer
                {
                    Id = 4, Name = "Rubics"
                });
            modelBuilder.Entity<Puzzle>().HasData(
                new Puzzle
                {
                    Id = 1, Name = "Gan 356 X", 
                    IsWcaPuzzle = true, 
                    Weight = 350, 
                    DateWhenAdded = DateTimeOffset.Now, 
                    ManufacturerId = 1, 
                    PuzzleTypeId = 1,
                    ColorId = 3,
                    DifficultyLevelId = 2
                },
                new Puzzle
                {
                    Id = 2, Name = "Gan 356 XS", 
                    IsWcaPuzzle = true, 
                    Weight = 330, 
                    DateWhenAdded = DateTimeOffset.Now, 
                    ManufacturerId = 1, 
                    PuzzleTypeId = 1,
                    ColorId = 1,
                    DifficultyLevelId = 2
                },
                new Puzzle
                {
                    Id = 3, Name = "MoYu Weilong GTS 3M", 
                    IsWcaPuzzle = true, 
                    Weight = 345, 
                    DateWhenAdded = DateTimeOffset.Now, 
                    ManufacturerId = 2, 
                    PuzzleTypeId = 1,
                    ColorId = 3,
                    DifficultyLevelId = 2
                });
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1, FileName = "testfilename", PuzzleId = 1
                },
                new Image
                {
                    Id = 2, FileName = "testfilename", PuzzleId = 2
                });
        }
    }
}
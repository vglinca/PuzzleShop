﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PuzzleShop.Persistance.DbContext;

namespace PuzzleShop.Persistance.Migrations
{
    [DbContext(typeof(PuzzleShopContext))]
    partial class PuzzleShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Color", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlasticColors");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "White"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "Black"
                        },
                        new
                        {
                            Id = 3L,
                            Title = "Stickerless"
                        },
                        new
                        {
                            Id = 4L,
                            Title = "Pink"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.DifficultyLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Levels");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Low"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "Middle"
                        },
                        new
                        {
                            Id = 3L,
                            Title = "High"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PuzzleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PuzzleId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FileName = "testfilename",
                            PuzzleId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            FileName = "testfilename",
                            PuzzleId = 2L
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Gan"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "MoYu"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "QiYi"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Rubics"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "DaYan"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "YJ"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.MaterialType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaterialType");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Plastic"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Puzzle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ColorId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateWhenAdded")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DifficultyLevelId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsWcaPuzzle")
                        .HasColumnType("bit");

                    b.Property<long>("ManufacturerId")
                        .HasColumnType("bigint");

                    b.Property<long>("MaterialTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("PuzzleTypeId")
                        .HasColumnType("bigint");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("DifficultyLevelId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("MaterialTypeId");

                    b.HasIndex("PuzzleTypeId");

                    b.ToTable("Puzzles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 879, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 1L,
                            MaterialTypeId = 1L,
                            Name = "Gan 356 X",
                            Price = 45.0m,
                            PuzzleTypeId = 1L,
                            Weight = 350.0
                        },
                        new
                        {
                            Id = 2L,
                            ColorId = 1L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 1L,
                            MaterialTypeId = 1L,
                            Name = "Gan 356 XS",
                            Price = 60.0m,
                            PuzzleTypeId = 1L,
                            Weight = 330.0
                        },
                        new
                        {
                            Id = 3L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 2L,
                            MaterialTypeId = 1L,
                            Name = "MoYu Weilong GTS 3M",
                            Price = 30.0m,
                            PuzzleTypeId = 1L,
                            Weight = 345.0
                        },
                        new
                        {
                            Id = 4L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 5L,
                            MaterialTypeId = 1L,
                            Name = "DaYan 7 TengYun",
                            Price = 25.0m,
                            PuzzleTypeId = 1L,
                            Weight = 334.0
                        },
                        new
                        {
                            Id = 5L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 1L,
                            MaterialTypeId = 1L,
                            Name = "Gan 354 M",
                            Price = 34.0m,
                            PuzzleTypeId = 1L,
                            Weight = 290.0
                        },
                        new
                        {
                            Id = 6L,
                            ColorId = 1L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 3L,
                            MaterialTypeId = 1L,
                            Name = "QiYi Valk Power M",
                            Price = 17.0m,
                            PuzzleTypeId = 1L,
                            Weight = 330.0
                        },
                        new
                        {
                            Id = 7L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 3L,
                            MaterialTypeId = 1L,
                            Name = "QiYi WuQue Mini M",
                            Price = 24.0m,
                            PuzzleTypeId = 2L,
                            Weight = 330.0
                        },
                        new
                        {
                            Id = 8L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 1L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 3L,
                            MaterialTypeId = 1L,
                            Name = "QiYi X-Man Skewb Wingy M",
                            Price = 12.0m,
                            PuzzleTypeId = 5L,
                            Weight = 220.0
                        },
                        new
                        {
                            Id = 9L,
                            ColorId = 2L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 1L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 2L,
                            MaterialTypeId = 1L,
                            Name = "MoYu Skewb AoYan M",
                            Price = 22.0m,
                            PuzzleTypeId = 5L,
                            Weight = 220.0
                        },
                        new
                        {
                            Id = 10L,
                            ColorId = 2L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 2, 0, 0, 0)),
                            DifficultyLevelId = 2L,
                            IsWcaPuzzle = true,
                            ManufacturerId = 2L,
                            MaterialTypeId = 1L,
                            Name = "MoYu Square-1 MeiLong",
                            Price = 10.0m,
                            PuzzleTypeId = 6L,
                            Weight = 220.0
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.PuzzleType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PuzzleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            TypeName = "3x3x3"
                        },
                        new
                        {
                            Id = 2L,
                            TypeName = "4x4x4"
                        },
                        new
                        {
                            Id = 3L,
                            TypeName = "5x5x5"
                        },
                        new
                        {
                            Id = 4L,
                            TypeName = "6x6x6"
                        },
                        new
                        {
                            Id = 5L,
                            TypeName = "skewb"
                        },
                        new
                        {
                            Id = 6L,
                            TypeName = "square-1"
                        },
                        new
                        {
                            Id = 7L,
                            TypeName = "Megaminx"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Image", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Puzzle", "Puzzle")
                        .WithMany("Images")
                        .HasForeignKey("PuzzleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Puzzle", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Color", "Color")
                        .WithMany("Puzzles")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleShop.Domain.Entities.DifficultyLevel", "DifficultyLevel")
                        .WithMany("Puzzles")
                        .HasForeignKey("DifficultyLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleShop.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Puzzles")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleShop.Domain.Entities.MaterialType", "MaterialType")
                        .WithMany("Puzzles")
                        .HasForeignKey("MaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleShop.Domain.Entities.PuzzleType", "PuzzleType")
                        .WithMany("Puzzles")
                        .HasForeignKey("PuzzleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

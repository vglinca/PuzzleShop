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

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles","Auth");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims","Auth");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users","Auth");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims","Auth");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins","Auth");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole","Auth");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserToken", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens","Auth");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Color", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

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
                    b.Property<long>("DifficultyLevelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DifficultyLevelId");

                    b.ToTable("DifficultyLevels");

                    b.HasData(
                        new
                        {
                            DifficultyLevelId = 0L,
                            Title = "Low"
                        },
                        new
                        {
                            DifficultyLevelId = 1L,
                            Title = "Medium"
                        },
                        new
                        {
                            DifficultyLevelId = 2L,
                            Title = "High"
                        },
                        new
                        {
                            DifficultyLevelId = 3L,
                            Title = "ExtraHigh"
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

                    b.ToTable("MaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Plastic"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("OrderStatusId")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalItems")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("PuzzleId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PuzzleId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<long>("OrderStatusId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrdeStatuses");

                    b.HasData(
                        new
                        {
                            OrderStatusId = 0L,
                            Name = "Pending"
                        },
                        new
                        {
                            OrderStatusId = 1L,
                            Name = "AwaitingPayment"
                        },
                        new
                        {
                            OrderStatusId = 2L,
                            Name = "ConfirmedPayment"
                        },
                        new
                        {
                            OrderStatusId = 3L,
                            Name = "AwaitingShipment"
                        },
                        new
                        {
                            OrderStatusId = 4L,
                            Name = "Completed"
                        },
                        new
                        {
                            OrderStatusId = 5L,
                            Name = "Cancelled"
                        },
                        new
                        {
                            OrderStatusId = 6L,
                            Name = "Declined"
                        },
                        new
                        {
                            OrderStatusId = 7L,
                            Name = "Refunded"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Puzzle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AvailableInStock")
                        .HasColumnType("bigint");

                    b.Property<long>("ColorId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateWhenAdded")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMagnetic")
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

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("MaterialTypeId");

                    b.HasIndex("PuzzleTypeId");

                    b.ToTable("Puzzles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AvailableInStock = 0L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 400, DateTimeKind.Unspecified).AddTicks(4277), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 1L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8665), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8684), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 1L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8695), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 3L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8703), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 2L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8710), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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
                            AvailableInStock = 0L,
                            ColorId = 2L,
                            DateWhenAdded = new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8714), new TimeSpan(0, 3, 0, 0, 0)),
                            IsMagnetic = true,
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

                    b.Property<long>("DifficultyLevelId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsRubicsCube")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWca")
                        .HasColumnType("bit");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyLevelId");

                    b.ToTable("PuzzleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DifficultyLevelId = 1L,
                            IsRubicsCube = true,
                            IsWca = true,
                            TypeName = "3x3x3"
                        },
                        new
                        {
                            Id = 2L,
                            DifficultyLevelId = 1L,
                            IsRubicsCube = true,
                            IsWca = true,
                            TypeName = "4x4x4"
                        },
                        new
                        {
                            Id = 3L,
                            DifficultyLevelId = 1L,
                            IsRubicsCube = true,
                            IsWca = true,
                            TypeName = "5x5x5"
                        },
                        new
                        {
                            Id = 4L,
                            DifficultyLevelId = 2L,
                            IsRubicsCube = true,
                            IsWca = true,
                            TypeName = "6x6x6"
                        },
                        new
                        {
                            Id = 5L,
                            DifficultyLevelId = 0L,
                            IsRubicsCube = false,
                            IsWca = true,
                            TypeName = "skewb"
                        },
                        new
                        {
                            Id = 6L,
                            DifficultyLevelId = 1L,
                            IsRubicsCube = false,
                            IsWca = true,
                            TypeName = "square-1"
                        },
                        new
                        {
                            Id = 7L,
                            DifficultyLevelId = 1L,
                            IsRubicsCube = false,
                            IsWca = true,
                            TypeName = "Megaminx"
                        });
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.RoleClaim", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserClaim", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserLogin", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserRole", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleShop.Domain.Entities.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Auth.UserToken", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Image", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Puzzle", "Puzzle")
                        .WithMany("Images")
                        .HasForeignKey("PuzzleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.Order", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleShop.Domain.Entities.Auth.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PuzzleShop.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleShop.Domain.Entities.Puzzle", "Puzzle")
                        .WithMany()
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

            modelBuilder.Entity("PuzzleShop.Domain.Entities.PuzzleType", b =>
                {
                    b.HasOne("PuzzleShop.Domain.Entities.DifficultyLevel", "DifficultyLevel")
                        .WithMany("PuzzlesTypes")
                        .HasForeignKey("DifficultyLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

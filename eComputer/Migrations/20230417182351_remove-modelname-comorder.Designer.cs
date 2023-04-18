﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eComputer.Data;

#nullable disable

namespace eComputer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230417182351_remove-modelname-comorder")]
    partial class removemodelnamecomorder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("eComputer.Models.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccessoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AccessoryPrice")
                        .HasColumnType("float");

                    b.Property<int>("AccessoryType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("eComputer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("eComputer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eComputer.Models.ComModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModelDefaultAntivirus")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultCPU")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultHDD")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultMemory")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultOS")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultSSD")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultVGA")
                        .HasColumnType("int");

                    b.Property<string>("ModelDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ModelPrice")
                        .HasColumnType("float");

                    b.Property<int?>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ModelDefaultAntivirus");

                    b.HasIndex("ModelDefaultCPU");

                    b.HasIndex("ModelDefaultHDD");

                    b.HasIndex("ModelDefaultMemory");

                    b.HasIndex("ModelDefaultOS");

                    b.HasIndex("ModelDefaultSSD");

                    b.HasIndex("ModelDefaultVGA");

                    b.HasIndex("SeriesId");

                    b.ToTable("ComModels");
                });

            modelBuilder.Entity("eComputer.Models.ComModel_Accessory", b =>
                {
                    b.Property<int>("ComModelId")
                        .HasColumnType("int");

                    b.Property<int>("AccessoryId")
                        .HasColumnType("int");

                    b.HasKey("ComModelId", "AccessoryId");

                    b.HasIndex("AccessoryId");

                    b.ToTable("ComModels_Accessories");
                });

            modelBuilder.Entity("eComputer.Models.ComOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ComModelId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultAntivirus")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultCPU")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultHDD")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultMemory")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultOS")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultSSD")
                        .HasColumnType("int");

                    b.Property<int?>("ModelDefaultVGA")
                        .HasColumnType("int");

                    b.Property<double>("ModelPrice")
                        .HasColumnType("float");

                    b.Property<int?>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ComModelId");

                    b.HasIndex("ModelDefaultAntivirus");

                    b.HasIndex("ModelDefaultCPU");

                    b.HasIndex("ModelDefaultHDD");

                    b.HasIndex("ModelDefaultMemory");

                    b.HasIndex("ModelDefaultOS");

                    b.HasIndex("ModelDefaultSSD");

                    b.HasIndex("ModelDefaultVGA");

                    b.HasIndex("SeriesId");

                    b.ToTable("ComOrders");
                });

            modelBuilder.Entity("eComputer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eComputer.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ComOrderId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ComOrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("eComputer.Models.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SeriesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Serieses");
                });

            modelBuilder.Entity("eComputer.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("comOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("comOrderId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("eComputer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("eComputer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eComputer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("eComputer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eComputer.Models.ComModel", b =>
                {
                    b.HasOne("eComputer.Models.Category", "Category")
                        .WithMany("ComModels")
                        .HasForeignKey("CategoryId");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryAntivirus")
                        .WithMany()
                        .HasForeignKey("ModelDefaultAntivirus");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryCPU")
                        .WithMany()
                        .HasForeignKey("ModelDefaultCPU");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryHDD")
                        .WithMany()
                        .HasForeignKey("ModelDefaultHDD");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryMemory")
                        .WithMany()
                        .HasForeignKey("ModelDefaultMemory");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryOS")
                        .WithMany()
                        .HasForeignKey("ModelDefaultOS");

                    b.HasOne("eComputer.Models.Accessory", "AccessorySSD")
                        .WithMany()
                        .HasForeignKey("ModelDefaultSSD");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryVGA")
                        .WithMany()
                        .HasForeignKey("ModelDefaultVGA");

                    b.HasOne("eComputer.Models.Series", "Series")
                        .WithMany("ComModels")
                        .HasForeignKey("SeriesId");

                    b.Navigation("AccessoryAntivirus");

                    b.Navigation("AccessoryCPU");

                    b.Navigation("AccessoryHDD");

                    b.Navigation("AccessoryMemory");

                    b.Navigation("AccessoryOS");

                    b.Navigation("AccessorySSD");

                    b.Navigation("AccessoryVGA");

                    b.Navigation("Category");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("eComputer.Models.ComModel_Accessory", b =>
                {
                    b.HasOne("eComputer.Models.Accessory", "Accessory")
                        .WithMany("ComModels_Accessories")
                        .HasForeignKey("AccessoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eComputer.Models.ComModel", "ComModel")
                        .WithMany("ComModels_Accessories")
                        .HasForeignKey("ComModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accessory");

                    b.Navigation("ComModel");
                });

            modelBuilder.Entity("eComputer.Models.ComOrder", b =>
                {
                    b.HasOne("eComputer.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("eComputer.Models.ComModel", "ComModel")
                        .WithMany("ComOrders")
                        .HasForeignKey("ComModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eComputer.Models.Accessory", "AccessoryAntivirus")
                        .WithMany()
                        .HasForeignKey("ModelDefaultAntivirus");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryCPU")
                        .WithMany()
                        .HasForeignKey("ModelDefaultCPU");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryHDD")
                        .WithMany()
                        .HasForeignKey("ModelDefaultHDD");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryMemory")
                        .WithMany()
                        .HasForeignKey("ModelDefaultMemory");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryOS")
                        .WithMany()
                        .HasForeignKey("ModelDefaultOS");

                    b.HasOne("eComputer.Models.Accessory", "AccessorySSD")
                        .WithMany()
                        .HasForeignKey("ModelDefaultSSD");

                    b.HasOne("eComputer.Models.Accessory", "AccessoryVGA")
                        .WithMany()
                        .HasForeignKey("ModelDefaultVGA");

                    b.HasOne("eComputer.Models.Series", "Series")
                        .WithMany()
                        .HasForeignKey("SeriesId");

                    b.Navigation("AccessoryAntivirus");

                    b.Navigation("AccessoryCPU");

                    b.Navigation("AccessoryHDD");

                    b.Navigation("AccessoryMemory");

                    b.Navigation("AccessoryOS");

                    b.Navigation("AccessorySSD");

                    b.Navigation("AccessoryVGA");

                    b.Navigation("Category");

                    b.Navigation("ComModel");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("eComputer.Models.Order", b =>
                {
                    b.HasOne("eComputer.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eComputer.Models.OrderItem", b =>
                {
                    b.HasOne("eComputer.Models.ComOrder", "ComOrder")
                        .WithMany()
                        .HasForeignKey("ComOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eComputer.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComOrder");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("eComputer.Models.Series", b =>
                {
                    b.HasOne("eComputer.Models.Category", "Category")
                        .WithMany("Serieses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("eComputer.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("eComputer.Models.ComOrder", "comOrder")
                        .WithMany()
                        .HasForeignKey("comOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comOrder");
                });

            modelBuilder.Entity("eComputer.Models.Accessory", b =>
                {
                    b.Navigation("ComModels_Accessories");
                });

            modelBuilder.Entity("eComputer.Models.Category", b =>
                {
                    b.Navigation("ComModels");

                    b.Navigation("Serieses");
                });

            modelBuilder.Entity("eComputer.Models.ComModel", b =>
                {
                    b.Navigation("ComModels_Accessories");

                    b.Navigation("ComOrders");
                });

            modelBuilder.Entity("eComputer.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("eComputer.Models.Series", b =>
                {
                    b.Navigation("ComModels");
                });
#pragma warning restore 612, 618
        }
    }
}

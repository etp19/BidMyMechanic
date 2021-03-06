﻿// <auto-generated />
using System;
using BidMyMechanic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BidMyMechanic.Entities.Migrations
{
    [DbContext(typeof(BidMyMechanicContext))]
    [Migration("20191028031013_latestMig")]
    partial class latestMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BidTimePeriod")
                        .HasColumnType("datetime2");

                    b.Property<string>("BidUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("IncludeParts")
                        .HasColumnType("int");

                    b.Property<int?>("IssueId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("WinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WinnerIdId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BidUserId");

                    b.HasIndex("ClientId");

                    b.HasIndex("IssueId");

                    b.HasIndex("WinnerIdId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.BidUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BidUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BidUserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BidUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("IssueTrackingId")
                        .HasColumnType("int");

                    b.Property<string>("IssueType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BidUserId");

                    b.HasIndex("ClientId");

                    b.HasIndex("IssueTrackingId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.IssueTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StatusDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("IssueTrackings");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BidUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reviews")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BidUserId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UHighway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("barrels08")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city08")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city08U")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("co2TailpipeGpm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("comb08")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cylinders")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("displ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("drive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("engId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eng_dscr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("feScore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fuelCost08")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fuelCostA08")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fuelType1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("highway08")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trans_dscr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("youSaveSpend")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Bid", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", "BidUser")
                        .WithMany()
                        .HasForeignKey("BidUserId");

                    b.HasOne("BidMyMechanic.Entities.Entities.Client", null)
                        .WithMany("BidHistory")
                        .HasForeignKey("ClientId");

                    b.HasOne("BidMyMechanic.Entities.Entities.Issue", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");

                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", "WinnerId")
                        .WithMany()
                        .HasForeignKey("WinnerIdId");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Client", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", "BidUser")
                        .WithMany()
                        .HasForeignKey("BidUserId");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Issue", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", "BidUser")
                        .WithMany()
                        .HasForeignKey("BidUserId");

                    b.HasOne("BidMyMechanic.Entities.Entities.Client", null)
                        .WithMany("IssueHistory")
                        .HasForeignKey("ClientId");

                    b.HasOne("BidMyMechanic.Entities.Entities.IssueTracking", "IssueTracking")
                        .WithMany()
                        .HasForeignKey("IssueTrackingId");

                    b.HasOne("BidMyMechanic.Entities.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Supplier", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", "BidUser")
                        .WithMany()
                        .HasForeignKey("BidUserId");
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
                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", null)
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

                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.BidUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

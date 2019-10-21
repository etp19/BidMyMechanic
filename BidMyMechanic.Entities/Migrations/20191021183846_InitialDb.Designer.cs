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
    [Migration("20191021183846_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BidMyMechanic.Entities.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BidTimePeriod")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IssueTrackingId")
                        .HasColumnType("int");

                    b.Property<string>("IssueType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Engine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Bid", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("BidMyMechanic.Entities.Entities.Issue", b =>
                {
                    b.HasOne("BidMyMechanic.Entities.Entities.IssueTracking", "IssueTracking")
                        .WithMany()
                        .HasForeignKey("IssueTrackingId");

                    b.HasOne("BidMyMechanic.Entities.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });
#pragma warning restore 612, 618
        }
    }
}

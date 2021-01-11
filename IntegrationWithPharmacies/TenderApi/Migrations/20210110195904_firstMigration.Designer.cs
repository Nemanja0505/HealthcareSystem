﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TenderApi.DbContextModel;

namespace TenderApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210110195904_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TenderApi.Model.MedicineForTendering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MedicineForTendering");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Andol",
                            Quantity = 135,
                            TenderId = 1
                        });
                });

            modelBuilder.Entity("TenderApi.Model.MedicineTenderOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("MedicineName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PharmacyTenderOfferId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MedicineTenderOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQuantity = 1,
                            MedicineName = "Andol",
                            PharmacyTenderOfferId = 1,
                            Price = 1.0,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("TenderApi.Model.PharmacyTenderOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PharmacyTenderOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsWinner = false,
                            PharmacyName = "pharmacy Jankovic",
                            TenderId = 1
                        });
                });

            modelBuilder.Entity("TenderApi.Model.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ActiveUntil")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Closed")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Tender");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActiveUntil = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Closed = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

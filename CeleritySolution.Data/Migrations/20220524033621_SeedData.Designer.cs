﻿// <auto-generated />
using System;
using CeleritySolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CeleritySolution.Data.Migrations
{
    [DbContext(typeof(CelerityDbContext))]
    [Migration("20220524033621_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CeleritySolution.Data.Entities.Agreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AgreementName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgreementType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8764));

                    b.Property<int>("DaysUntilExplation")
                        .HasColumnType("int");

                    b.Property<int>("DistributorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EffectiveDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8104));

                    b.Property<DateTime>("ExpirationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8465));

                    b.Property<string>("QuoteNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistributorId");

                    b.ToTable("Agreements", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgreementName = "HP PACK AIR INC",
                            AgreementType = "SPA",
                            CreatedDate = new DateTime(2022, 5, 24, 10, 36, 21, 367, DateTimeKind.Local).AddTicks(643),
                            DaysUntilExplation = 1,
                            DistributorId = 1,
                            EffectiveDate = new DateTime(2022, 5, 24, 10, 36, 21, 367, DateTimeKind.Local).AddTicks(639),
                            ExpirationDate = new DateTime(2022, 5, 24, 10, 36, 21, 367, DateTimeKind.Local).AddTicks(643),
                            QuoteNumber = "02776A3",
                            Status = "Invalid"
                        });
                });

            modelBuilder.Entity("CeleritySolution.Data.Entities.Distributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DistributorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Distributors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistributorName = "Werner"
                        });
                });

            modelBuilder.Entity("CeleritySolution.Data.Entities.Agreement", b =>
                {
                    b.HasOne("CeleritySolution.Data.Entities.Distributor", "Distributor")
                        .WithMany("Agreements")
                        .HasForeignKey("DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("CeleritySolution.Data.Entities.Distributor", b =>
                {
                    b.Navigation("Agreements");
                });
#pragma warning restore 612, 618
        }
    }
}
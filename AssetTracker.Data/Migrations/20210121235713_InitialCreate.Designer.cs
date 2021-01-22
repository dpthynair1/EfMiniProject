﻿// <auto-generated />
using System;
using AssetTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetTracker.Data.Migrations
{
    [DbContext(typeof(AssetContext))]
    [Migration("20210121235713_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AssetTracker.Domain.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AssetId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Assets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Asset");
                });

            modelBuilder.Entity("AssetTracker.Domain.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("AssetTracker.Domain.Computer", b =>
                {
                    b.HasBaseType("AssetTracker.Domain.Asset");

                    b.Property<int>("ComputerId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Computer");
                });

            modelBuilder.Entity("AssetTracker.Domain.Mobile", b =>
                {
                    b.HasBaseType("AssetTracker.Domain.Asset");

                    b.Property<int>("MobileId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Mobile");
                });

            modelBuilder.Entity("AssetTracker.Domain.Asset", b =>
                {
                    b.HasOne("AssetTracker.Domain.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId");

                    b.Navigation("Office");
                });
#pragma warning restore 612, 618
        }
    }
}

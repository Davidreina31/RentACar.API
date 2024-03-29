﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentACar.DAL.Data;

namespace RentACar.DAL.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20220329171952_addPriceToTripTable")]
    partial class addPriceToTripTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentACar.MODELS.Car", b =>
                {
                    b.Property<Guid>("Car_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Desktop_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Km_End")
                        .HasColumnType("bigint");

                    b.Property<long>("Km_Start")
                        .HasColumnType("bigint");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Car_Id");

                    b.HasIndex("Desktop_Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RentACar.MODELS.Country", b =>
                {
                    b.Property<Guid>("Country_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Km_Price")
                        .HasColumnType("float");

                    b.HasKey("Country_Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RentACar.MODELS.Desktop", b =>
                {
                    b.Property<Guid>("Desktop_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Country_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Desktop_Id");

                    b.HasIndex("Country_Id");

                    b.ToTable("Desktops");
                });

            modelBuilder.Entity("RentACar.MODELS.Package", b =>
                {
                    b.Property<Guid>("Package_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Desktop_EndDesktop_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Desktop_End_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Desktop_StartDesktop_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Desktop_Start_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Km_Limit")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Package_Id");

                    b.HasIndex("Desktop_EndDesktop_Id");

                    b.HasIndex("Desktop_StartDesktop_Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("RentACar.MODELS.Trip", b =>
                {
                    b.Property<Guid>("Trip_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Car_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("Desktop_EndDesktop_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Desktop_End_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Desktop_StartDesktop_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Desktop_Start_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPackage")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Trip_Id");

                    b.HasIndex("Car_Id");

                    b.HasIndex("Desktop_EndDesktop_Id");

                    b.HasIndex("Desktop_StartDesktop_Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("RentACar.MODELS.Car", b =>
                {
                    b.HasOne("RentACar.MODELS.Desktop", "Desktop")
                        .WithMany("Cars")
                        .HasForeignKey("Desktop_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desktop");
                });

            modelBuilder.Entity("RentACar.MODELS.Desktop", b =>
                {
                    b.HasOne("RentACar.MODELS.Country", "Country")
                        .WithMany()
                        .HasForeignKey("Country_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RentACar.MODELS.Package", b =>
                {
                    b.HasOne("RentACar.MODELS.Desktop", "Desktop_End")
                        .WithMany()
                        .HasForeignKey("Desktop_EndDesktop_Id");

                    b.HasOne("RentACar.MODELS.Desktop", "Desktop_Start")
                        .WithMany()
                        .HasForeignKey("Desktop_StartDesktop_Id");

                    b.Navigation("Desktop_End");

                    b.Navigation("Desktop_Start");
                });

            modelBuilder.Entity("RentACar.MODELS.Trip", b =>
                {
                    b.HasOne("RentACar.MODELS.Car", "Car")
                        .WithMany()
                        .HasForeignKey("Car_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.MODELS.Desktop", "Desktop_End")
                        .WithMany()
                        .HasForeignKey("Desktop_EndDesktop_Id");

                    b.HasOne("RentACar.MODELS.Desktop", "Desktop_Start")
                        .WithMany()
                        .HasForeignKey("Desktop_StartDesktop_Id");

                    b.Navigation("Car");

                    b.Navigation("Desktop_End");

                    b.Navigation("Desktop_Start");
                });

            modelBuilder.Entity("RentACar.MODELS.Desktop", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}

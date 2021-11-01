﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantAPI.Data;

namespace RestaurantAPI.Migrations
{
    [DbContext(typeof(AppDbContexxt))]
    partial class AppDbContexxtModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantAPI.Models.MenuItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Name = "Spaghetti",
                            Price = 19.25
                        });
                });

            modelBuilder.Entity("RestaurantAPI.Models.MenuItemsReserved", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuItemID")
                        .HasColumnType("int");

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemID");

                    b.HasIndex("ReservationID");

                    b.ToTable("MenuItemsReserveds");

                    b.HasData(
                        new
                        {
                            Id = 3001,
                            MenuItemID = 1001,
                            ReservationID = 2001
                        });
                });

            modelBuilder.Entity("RestaurantAPI.Models.Reservations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 2001,
                            Date = new DateTime(2021, 11, 1, 15, 40, 20, 263, DateTimeKind.Local).AddTicks(480),
                            Name = "Ryan's"
                        });
                });

            modelBuilder.Entity("RestaurantAPI.Models.MenuItemsReserved", b =>
                {
                    b.HasOne("RestaurantAPI.Models.MenuItems", "MenuItems")
                        .WithMany()
                        .HasForeignKey("MenuItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAPI.Models.Reservations", "Reservations")
                        .WithMany()
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}

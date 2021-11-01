using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data
{
    public class AppDbContexxt : DbContext
    {
        public AppDbContexxt(DbContextOptions<AppDbContexxt> options) : base(options) { }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<MenuItemsReserved> MenuItemsReserveds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItems>().HasData(
                new MenuItems { Id = 1001, Name = "Spaghetti", Price = 19.25}
                );

            modelBuilder.Entity<Reservations>().HasData(
                new Reservations { Id = 2001, Name = "Ryan's", Date = DateTime.Now }
                );

            modelBuilder.Entity<MenuItemsReserved>().HasData(
                new MenuItemsReserved { Id = 3001, MenuItemID = 1001, ReservationID = 2001 }
                );
        }
    }
}

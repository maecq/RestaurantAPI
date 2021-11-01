using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class MenuItemsReserved
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MenuItems")]
        public int MenuItemID { get; set; }
        public MenuItems MenuItems { get; set; }


        [ForeignKey("Reservations")]
        public int ReservationID { get; set; }
        public Reservations Reservations { get; set; }

    }
}

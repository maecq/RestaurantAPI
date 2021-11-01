﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Reservations
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

    }
}

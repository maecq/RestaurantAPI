using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class MenuItems
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }


    }
}

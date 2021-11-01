using RestaurantAPI.Models;
using RestaurantAPI.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data
{
    public class Mapper
    {
        public MenuItems Map(MenuItemsDTO input)
        {
            return new MenuItems
            {
                Name = input.Name,
                Price = input.Price
            };
        }
        public MenuItemsDTO Map(MenuItems input)
        {
            return new MenuItemsDTO
            {
                Name = input.Name,
                Price = input.Price
            };
        }


    }
}

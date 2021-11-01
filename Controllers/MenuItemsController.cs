using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly AppDbContexxt _context;
        private readonly Mapper _mapper = new Mapper();

        public MenuItemsController(AppDbContexxt contexxt)
        {
            _context = contexxt;
        }

        // GET: api/<MenuItemsController>
        [HttpGet]
        public ActionResult<IEnumerable<MenuItems>> Get()
        {
            return Ok(_context.MenuItems.ToList());
        }

        // GET api/<MenuItemsController>/5
        [HttpGet("{id}")]
        public ActionResult<MenuItems> Get(int id)
        {
            var menu = _context.MenuItems.FirstOrDefault(m => m.Id == id);
            if (menu != null)
            {
                return Ok(menu);
            }
            return NotFound();
        }

        // POST api/<MenuItemsController>
        [HttpPost]
        public ActionResult<MenuItems> Post(MenuItemsDTO value)
        {
            MenuItems menuItems = _mapper.Map(value);
            _context.Add(menuItems);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<MenuItemsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, MenuItemsDTO value)
        {
            var menuFromDb = _context.MenuItems.FirstOrDefault(m => m.Id == id);
            if (menuFromDb == null) return NotFound();

            menuFromDb.Name = value.Name;
            menuFromDb.Price = value.Price;

            _context.Update(menuFromDb);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<MenuItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var menuFromDb = _context.MenuItems.FirstOrDefault(m => m.Id == id);
            if (menuFromDb == null) return NotFound();

            _context.MenuItems.Remove(menuFromDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

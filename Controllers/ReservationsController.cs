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
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContexxt _context;

        public ReservationsController(AppDbContexxt context)
        {
            _context = context;
        }

        // GET: api/<ReservationsController>
        [HttpGet]
        public ActionResult Get()
        {
            var reserves = _context.Reservations
                .Select(r => new ReservationsReadDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Date = r.Date,
                    MenuItems = _context.MenuItemsReserveds
                        .Where(mr => mr.ReservationID == r.Id)
                        .Select(c => new MenuItemsReadDTO
                        {
                            Id = c.MenuItemID,
                            Name = c.MenuItems.Name,
                            Price = c.MenuItems.Price
                        }).ToList()
                }).ToList();
            return Ok(reserves);
        }

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var reserves = _context.Reservations
                .Where(r => r.Id == id)
                .Select(r => new ReservationsReadDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Date = r.Date,
                    MenuItems = _context.MenuItemsReserveds
                        .Where(mr => mr.ReservationID == r.Id)
                        .Select(c => new MenuItemsReadDTO
                        {
                            Id = c.MenuItemID,
                            Name = c.MenuItems.Name,
                            Price = c.MenuItems.Price
                        }).ToList()
                }).FirstOrDefault();

            if (reserves == null) { return NotFound($"Reservation Number#{id} doesn't exist"); };

            return Ok(reserves);
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public ActionResult Post(ReservationsWriteDTO value)
        {
            Reservations reservations = new Reservations { Name = value.Name, Date = value.Date };
            _context.Reservations.Add(reservations);
            _context.SaveChanges();

            foreach (var id in value.MenuIDs)
            {
                MenuItemsReserved mr = new MenuItemsReserved { ReservationID = reservations.Id, MenuItemID = id };
                _context.MenuItemsReserveds.Add(mr);
            }
            _context.SaveChanges();
            return NoContent();
        }

        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ReservationsDTO value)
        {
            var reservationFromDB = _context.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservationFromDB == null) return NotFound();
            reservationFromDB.Name = value.Name;
            reservationFromDB.Date = value.Date;

            _context.Update(reservationFromDB);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var reservationFromDB = _context.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservationFromDB == null) return NotFound();
            _context.Reservations.Remove(reservationFromDB);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

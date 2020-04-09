using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12RelationalDatabases.Data;
using Lab12RelationalDatabases.Models;
using Lab12RelationalDatabases.Models.Interfaces;
using Lab12RelationalDatabases.DTOs;

namespace Lab12RelationalDatabases.Controllers
{
    //controller for Hotels table derived from base controller
    //allows for access to database through route /api/Hotels/
    [Route("api/Hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelManager _context;

        public HotelsController(IHotelManager context)
        {
            _context = context;
        }

        // GET: api/Hotels
        /// <summary>
        /// HTTP Get request which returns all hotels
        /// </summary>
        /// <returns>List of all hotels</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _context.GetAllHotels();
        }

        // GET: api/Hotels/5
        /// <summary>
        /// HTTP Get request which returns a hotel based on ID
        /// </summary>
        /// <returns>The hotel with the given ID</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _context.GetHotelByID(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// HTTP Put request to update data for a given hotel
        /// </summary>
        /// <param name="id">The ID of the hotel to update</param>
        /// <param name="hotel">The updated hotel object</param>
        /// <returns>Error on failure</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }

            await _context.Update(id, hotel);

            return NoContent();
        }            
        // POST: api/Hotels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// HTTP Post request to create a new hotel
        /// </summary>
        /// <param name="hotel">The hotel data to be added</param>
        /// <returns>The ID and object for the new hotel</returns>
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            var result = await _context.CreateHotel(hotel);
            
            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotels/5
        /// <summary>
        /// HTTP Delete request to remove a hotel
        /// </summary>
        /// <param name="id">The ID of the hotel to remove</param>
        /// <returns>The object form of the removed hotel</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            await _context.RemoveHotel(id);

            return NoContent();
        }

    }
}

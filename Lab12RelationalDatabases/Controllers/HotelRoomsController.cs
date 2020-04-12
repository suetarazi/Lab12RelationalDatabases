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
    /// <summary>
    /// Injection of database utilizing the ControllerBase dependency and giving the AsyncHotelDbContext the private name of _context
    /// </summary>
    [Route("api/hotel/room")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _context;

        public HotelRoomsController(IHotelRoom context)
        {
            _context = context;
        }

        /// <summary>
        /// Beginning of our CRUD method: this Gets a list of all HotelRooms
        /// </summary>
        /// <returns>A list of hotel rooms</returns>
        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms()
        {
            return await _context.GetAllHotelRooms();
        }

        /// <summary>
        /// this Gets a specific hotel room corresponding to an ID
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <returns>the specific hotel room that corresponds with the ID</returns>
        // GET: api/HotelRooms/5
        [HttpGet, Route("{hotelID}/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomnumber)
        {
            var hotelRoom = await _context.GetHotelRoomByRoomNumber(hotelId, roomnumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        /// <summary>
        /// Updates an amenity with a given ID and name
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <param name="hotelRoom">string hotelRoom</param>
        /// <returns>an error if it fails</returns>
        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut, Route("{hotelID}/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int id, int roomNumber, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelID || roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            await _context.UpdateHotelRoom(id, hotelRoom);

            return NoContent();
        }

        /// <summary>
        /// Creates a new amenity and assigns it an ID
        /// </summary>
        /// <param name="hotelRoom">string hotelRoom</param>
        /// <returns>new ID and hotelRoom</returns>
        // POST: api/HotelRooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost, Route("{HotelId}")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            await _context.CreateHotelRoom(hotelRoom);

            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelID }, hotelRoom);
        }

        /// <summary>
        /// Deletes and amenity with corresponding ID
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <returns>hotelRoom to be deleted</returns>
        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            await _context.RemoveHotelRoom(hotelId, roomNumber);

            return NoContent();
        }
    }
}

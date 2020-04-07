using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12RelationalDatabases.Data;
using Lab12RelationalDatabases.Models;

namespace Lab12RelationalDatabases.Controllers
{
    //controller for Rooms table derived from base controller
    //allows for access to database through route /api/Rooms/
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly AsyncHotelsDbContext _context;

        public RoomsController(AsyncHotelsDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        /// <summary>
        /// HTTP Get request which returns all rooms
        /// </summary>
        /// <returns>List of all rooms</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        /// <summary>
        /// HTTP Get request which returns a room based on ID
        /// </summary>
        /// <returns>The room with the given ID</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// HTTP Put request to update data for a given room
        /// </summary>
        /// <param name="id">The ID of the room to update</param>
        /// <param name="hotel">The updated room object</param>
        /// <returns>Error on failure</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// HTTP Post request to create a new room
        /// </summary>
        /// <param name="hotel">The room data to be added</param>
        /// <returns>The ID and object for the new room</returns>
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        /// <summary>
        /// HTTP Delete request to remove a room
        /// </summary>
        /// <param name="id">The ID of the room to remove</param>
        /// <returns>The object form of the removed room</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        /// <summary>
        /// Query to find if a room exists by ID
        /// </summary>
        /// <param name="id">The ID to check for</param>
        /// <returns>True if given ID exists</returns>
        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.ID == id);
        }
    }
}

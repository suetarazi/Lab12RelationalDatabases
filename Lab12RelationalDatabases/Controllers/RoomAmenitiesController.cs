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
    //controller for RoomAmenities table derived from base controller
    //allows for access to database through route /api/RoomAmenities/
    [Route("api/Rooms/Amenities")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly AsyncHotelsDbContext _context;

        public RoomAmenitiesController(AsyncHotelsDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomAmenities
        /// <summary>
        /// HTTP Get request which returns all room amenities
        /// </summary>
        /// <returns>List of all room amenities</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenities>>> GetRoomAmenities()
        {
            return await _context.RoomAmenities.ToListAsync();
        }

        // GET: api/RoomAmenities/5
        /// <summary>
        /// HTTP Get request which returns a room amenity based on ID
        /// </summary>
        /// <returns>The room amenity with the given ID</
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAmenities>> GetRoomAmenities(string id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);

            if (roomAmenities == null)
            {
                return NotFound();
            }

            return roomAmenities;
        }

        // PUT: api/RoomAmenities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// HTTP Put request to update data for a given room amenity
        /// </summary>
        /// <param name="id">The ID of the room amenity to update</param>
        /// <param name="hotel">The updated room amenity object</param>
        /// <returns>Error on failure</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomAmenities(string id, RoomAmenities roomAmenities)
        {
            if (Convert.ToInt32(id) != roomAmenities.AmenitiesID)
            {
                return BadRequest();
            }

            _context.Entry(roomAmenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomAmenitiesExists(id))
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

        // POST: api/RoomAmenities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost, Route("{RoomId}/{AmenitiesID}")]

        public async Task<ActionResult<RoomAmenities>> PostRoomAmenities(int roomId, int amenitiesId)
        {
            RoomAmenities newAmenities = new RoomAmenities();
            newAmenities.RoomID = roomId;
            newAmenities.AmenitiesID = amenitiesId;
            _context.RoomAmenities.Add(newAmenities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomAmenitiesExists(Convert.ToString(newAmenities.AmenitiesID)))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomAmenities", new { id = newAmenities.AmenitiesID }, newAmenities);
        }

        // DELETE: api/RoomAmenities/5
        /// <summary>
        /// HTTP Delete request to remove a room amenity
        /// </summary>
        /// <param name="id">The ID of the room amenity to remove</param>
        /// <returns>The object form of the removed room amenity</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomAmenities>> DeleteRoomAmenities(string id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();

            return roomAmenities;
        }

        /// <summary>
        /// Query to find if a room amenity exists by ID
        /// </summary>
        /// <param name="id">The ID to check for</param>
        /// <returns>True if given ID exists</returns>
        private bool RoomAmenitiesExists(string id)
        {
            return _context.RoomAmenities.Any(e => e.AmenitiesID == Convert.ToInt32(id));
        }
    }
}

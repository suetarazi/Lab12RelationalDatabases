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
    /// <summary>
    /// Injection of database utilizing the ControllerBase dependency and giving the AsyncHotelDbContext the private name of _context
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly AsyncHotelsDbContext _context;

        public AmenitiesController(AsyncHotelsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Beginning of our CRUD method: this Gets a list of all amenities
        /// </summary>
        /// <returns>A list of amenities</returns>
        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        /// <summary>
        /// this Gets a specific amenity corresponding to an ID
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <returns>the specific amenity that corresponds with the ID</returns>
        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenities(int id)
        {
            var amenities = await _context.Amenities.FindAsync(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        /// <summary>
        /// Updates an amenity with a given ID and name
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <param name="amenities">string amenity</param>
        /// <returns>an error if it fails</returns>
        // PUT: api/Amenities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return BadRequest();
            }

            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(id))
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

        /// <summary>
        /// Creates a new amenity and assigns it an ID
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns>new ID and amenity</returns>
        // POST: api/Amenities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmenities", new { id = amenities.ID }, amenities);
        }

        /// <summary>
        /// Deletes and amenity with corresponding ID
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <returns>amenity to be deleted</returns>
        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            var amenities = await _context.Amenities.FindAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }

            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();

            return amenities;
        }

        /// <summary>
        /// Boolean method to see if amenities exist
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <returns>true or false</returns>
        private bool AmenitiesExists(int id)
        {
            return _context.Amenities.Any(e => e.ID == id);
        }
    }
}

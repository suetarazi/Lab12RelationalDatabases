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

namespace Lab12RelationalDatabases.Controllers
{
    /// <summary>
    /// Injection of database utilizing the ControllerBase dependency and giving the AsyncHotelDbContext the private name of _context
    /// </summary>
    [Route("api/amenities")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenitiesManager _context;

        public AmenitiesController(IAmenitiesManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Beginning of our CRUD method: this Gets a list of all amenities
        /// </summary>
        /// <returns>A list of amenities</returns>
        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAllAmenities()
        {
            return await _context.GetAllAmenities();
        }

        /// <summary>
        /// this Gets a specific amenity corresponding to an ID
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <returns>the specific amenity that corresponds with the ID</returns>
        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenitiesByID(int id)
        {
            var amenities = await _context.GetAmenitiesByID(id);

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
        public async Task<IActionResult> UpdateAmenities(int id, Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return BadRequest();
            }

            await _context.UpdateAmenities(id, amenities);

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
        public async Task<ActionResult<Amenities>> CreateAmenities(Amenities amenities)
        {
            var result = await _context.CreateAmenities(amenities);

            return CreatedAtAction("GetAmenities", new { id = amenities.ID }, amenities);
        }

        /// <summary>
        /// Deletes and amenity with corresponding ID
        /// </summary>
        /// <param name="id">integer ID</param>
        /// <returns>amenity to be deleted</returns>
        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> RemoveAmenities(int id)
        {
            await _context.RemoveAmenities(id);

            return NoContent();
        }
    }
}

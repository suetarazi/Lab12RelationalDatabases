using Lab12RelationalDatabases.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12RelationalDatabases.Models.Interfaces;

namespace Lab12RelationalDatabases.Models.Services
{
    public class AmenitiesService : IAmenitiesManager
    {
        private AsyncHotelsDbContext _context;
        public AmenitiesService(AsyncHotelsDbContext context)
        {
            _context = context;
        }

        public async Task<Amenities> CreateAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task<List<Amenities>> GetAllAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenitiesByID(int amenitiesID)
        {
            Amenities amenities = await _context.Amenities.FindAsync(amenitiesID);
            return amenities;
        }

        public async Task UpdateAmenities(int amenitiesID, Amenities amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenities(int amenitiesID)
        {
            Amenities amenities = await GetAmenitiesByID(amenitiesID);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }
    }
}

using Lab12RelationalDatabases.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12RelationalDatabases.Models.Interfaces;
using Lab12RelationalDatabases.DTOs;

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

        public async Task<List<AmenitiesDTO>> GetAllAmenities()
        {
            var allAmenities = await _context.Amenities.ToListAsync();
            List<AmenitiesDTO> listAmenities = new List<AmenitiesDTO>();

            foreach (var amenity in allAmenities)
            {
                listAmenities.Add(new AmenitiesDTO
                {
                    ID = amenity.ID,
                    Name = amenity.Name
                });

            }
            return listAmenities;
        }

        public async Task<AmenitiesDTO> GetAmenitiesByID(int amenitiesID)
        {
            Amenities amenities = await _context.Amenities.FindAsync(amenitiesID);
            AmenitiesDTO amenitiesDto = new AmenitiesDTO
            {
                ID = amenities.ID,
                Name = amenities.Name,

            };
            return amenitiesDto;
        }

        public async Task UpdateAmenities(int amenitiesID, Amenities amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenities(int amenitiesID)
        {
            AmenitiesDTO amenitiesDTO = await GetAmenitiesByID(amenitiesID);
            
            //amenitiesDTO.CovertBackToAmenities()
            // covert DTO to amenities
            Amenities amenities = new Amenities()
            {
                ID = amenitiesDTO.ID,
                Name = amenitiesDTO.Name
            };
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }
    }
}

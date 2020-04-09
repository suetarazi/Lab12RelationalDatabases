using Lab12RelationalDatabases.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public interface IAmenitiesManager
    {
        //GET
        Task<List<AmenitiesDTO>> GetAllAmenities();
        Task<AmenitiesDTO> GetAmenitiesByID(int amenitiesID);

        //PUT
        Task UpdateAmenities(int amenitiesID, Amenities amenities);

        //POST
        Task<Amenities> CreateAmenities(Amenities amenities);

        //DELETE
        Task RemoveAmenities(int amenitiesID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public interface IAmenitiesManager
    {
        //GET
        Task<List<Amenities>> GetAllAmenities();
        Task<Amenities> GetAmenitiesByID(int amenitiesID);

        //PUT
        Task UpdateAmenities(int amenitiesID, Amenities amenities);

        //POST
        Task<Hotel> CreateAmenities(Amenities amenities);

        //DELETE
        Task<Amenities> RemoveAmenities(int amenitiesID);
    }
}

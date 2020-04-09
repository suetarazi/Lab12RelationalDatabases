using Lab12RelationalDatabases.Data;
using Lab12RelationalDatabases.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models.Services
{
    public class RoomService : IRoomsManager
    {
        private AsyncHotelsDbContext _context;
        private IAmenitiesManager _amenities;

        public RoomService(AsyncHotelsDbContext context, IAmenitiesManager amenities)
        {
            _context = context;
            _amenities = amenities;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            //add the newly created room to the db
            _context.Rooms.Add(room);
            //save to the db
            await _context.SaveChangesAsync();

            return room;
        }


        public async Task<List<Room>> GetAllRooms() => await _context.Rooms.ToListAsync();

        
        public async Task<Room> GetRoomByID(int roomId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);
            return room;
        }

        public async Task UpdateRoom(int roomId, Room room)
        {
            //set room equal to the one passed in
            _context.Entry(room).State = EntityState.Modified;

            //save changes
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRoom(int roomId)
        {
            Room room = await GetRoomByID(roomId);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenities>> GetAmenities(int roomId)
        {
            // getting all of the RoomAmenities where roomid == roomid
            // return a list RoomAmentities Objects
            var roomAmenities = await _context.RoomAmenities.Where(x => x.RoomID == roomId ).ToListAsync();

            // traverse over my amenities and get the individual details about each amentity. 
            List<Amenities> amenitiesResults = new List<Amenities>();

            foreach (var item in roomAmenities)
            {
                var items = await _amenities.GetAmenitiesByID(item.AmenitiesID);
                amenitiesResults.Add(items);
            }
            // Bring in your IAmenityManager into this service
            // in your foreach loop, you are going to call the _amenities.getamentitiesbyid(item.amenitiesId) method.
            // the returnedresult will be put into a list and returned.
            return amenitiesResults;
            
        }
    }
}

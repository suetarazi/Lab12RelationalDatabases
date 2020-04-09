using Lab12RelationalDatabases.Data;
using Lab12RelationalDatabases.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models.Services
{
    public class HotelRoomService : IHotelRoom
    {
        private AsyncHotelsDbContext _context;

        public HotelRoomService(AsyncHotelsDbContext context)
        {
            _context = context;
        }
        public Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public Task<List<HotelRoom>> GetAllHotelRooms()
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetByRoomNumber(int hotelID, int RoomNumber)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetRoomByID(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> RemoveHotelRoom(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task Update(int hotelID, HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}

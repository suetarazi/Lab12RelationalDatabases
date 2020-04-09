using Lab12RelationalDatabases.Data;
using Lab12RelationalDatabases.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetAllHotelRooms() => await _context.HotelRooms.ToListAsync();

        public async Task<List<HotelRoom>> GetAllHotelRoomsByHotel(int hotelId)
        {
            List<HotelRoom> hotelRooms = await _context.HotelRooms.Where(x => x.HotelID == hotelId).ToListAsync();
            return hotelRooms;
        }

        public async Task<HotelRoom> GetHotelRoomByRoomNumber(int hotelID, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelID, roomNumber);
            return hotelRoom;
        }

        public async Task<HotelRoom> GetHotelRoomByID(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomId);
            return hotelRoom;
        }

        public async Task RemoveHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoomByRoomNumber(hotelId, roomNumber);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelRoom(int hotelID, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

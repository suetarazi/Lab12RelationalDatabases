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

        public RoomService(AsyncHotelsDbContext context)
        {
            _context = context;
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

    }
}

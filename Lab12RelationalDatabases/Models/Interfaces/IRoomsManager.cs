using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models.Interfaces
{
    public interface IRoomsManager
    {
        //create a room
        Task<Room> CreateRoom(Room room);

        //update a room
        Task UpdateRoom(int roomId, Room room);

        //get all rooms
        Task<List<Room>> GetAllRooms();

        //get a single room by ID
        Task<Room> GetRoomByID(int roomId);

        //delete a room by ID
        Task RemoveRoom(int roomId);

    }
}

using Lab12RelationalDatabases.DTOs;
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
        Task<List<RoomDTO>> GetAllRooms();

        //get a single room by ID
        Task<RoomDTO> GetRoomByID(int roomId);

        //delete a room by ID
        Task RemoveRoom(int roomId);

        //get room amenities
        Task<List<AmenitiesDTO>> GetAmenities(int roomId);

        Task<List<AmenitiesDTO>> GetRoomAmenities(int roomId);
    }
}

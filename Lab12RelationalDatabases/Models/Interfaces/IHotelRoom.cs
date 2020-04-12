using Lab12RelationalDatabases.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models.Interfaces
{
    public interface IHotelRoom
    {
        //create a hotelroom
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);

        //update a hotelroom
        Task UpdateHotelRoom(int hotelID, HotelRoom hotelRoom);

        //get all hotelrooms
        Task<List<HotelRoomDTO>> GetAllHotelRooms();

        //get all hotelrooms in a single hotel
        Task<List<HotelRoomDTO>> GetAllHotelRoomsByHotel(int hotelId);

        //get by room number
        Task<HotelRoomDTO> GetHotelRoomByRoomNumber(int hotelID, int RoomNumber);

        //delete  a hotel room
        Task RemoveHotelRoom(int hotelId, int roomNumber);
    }
}


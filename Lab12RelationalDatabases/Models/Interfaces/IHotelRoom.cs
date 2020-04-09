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
        Task<List<HotelRoom>> GetAllHotelRooms();

        //get all hotelrooms in a single hotel
        Task<List<HotelRoom>> GetAllHotelRoomsByHotel(int hotelId);

        //get a single hotel room
        Task<HotelRoom> GetHotelRoomByID(int hotelId, int roomId);

        //delete  a hotel room
        Task RemoveHotelRoom(int hotelId, int roomNumber);

        //get by room number
        Task<HotelRoom> GetHotelRoomByRoomNumber(int hotelID, int RoomNumber);


    }
}


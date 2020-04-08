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

        Task Update(int hotelID, HotelRoom hotelRoom);

        //get all hotelrooms
        Task<List<HotelRoom>> GetAllHotelRooms();

        //get a single hotel room

        Task<HotelRoom> GetRoomByID(int hotelId);

        //delete  a hotel room
        Task<Hotel> RemoveHotelRoom(int hotelId);

        //get by room number
        Task<HotelRoom> GetByRoomNumber(int hotelID, int RoomNumber);


    }
}


using Lab12RelationalDatabases.Data;
using Lab12RelationalDatabases.DTOs;
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
        private IRoomsManager _roomData;

        public HotelRoomService(AsyncHotelsDbContext context, IRoomsManager room)
        {
            _context = context;
            _roomData = room;
        }
        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public Task<List<HotelRoomDTO>> GetAllHotelRooms()
        {
            throw new NotImplementedException();
        }

        //public async Task<List<HotelRoomDTO>> GetAllHotelRooms()
        //{
        //    var getAllHotelRooms = await _context.HotelRooms.ToListAsync();
        //    List<HotelRoomDTO> allHotelRooms = new List<HotelRoomDTO>();


        //    foreach (var hotelRoom in getAllHotelRooms)
        //    {
        //        List<AmenitiesDTO> roomAmenityDTO = await GetAllRooms();
        //        var hotelRoomDTO = new HotelRoomDTO()
        //        {
        //            HotelId = hotelRoom.HotelId,
        //            RoomNumber = hotelRoom.RoomNumber,
        //            Rate = hotelRoom.Rate,
        //            PetFriendly = hotelRoom.PetFriendly,
        //            RoomId = hotelRoom.RoomId,
        //            Room = AllDTOrooms,


        //            hotelRoomDTO.Add(hotelRoom);
        //        };
        //    allHotelRooms.Add(hotelRoomDTO);
        //    return allHotelRooms;
        //}

        public async Task<List<HotelRoomDTO>> GetAllHotelRoomsByHotel(int hotelId)
    {
        var hotelIdRooms = await _context.HotelRooms.Where(x => x.HotelID == hotelId).ToListAsync();
            List<HotelRoomDTO> hotelRooms = new List<HotelRoomDTO>();

            foreach (var room in hotelIdRooms)
            {
                HotelRoomDTO hotelroom = new HotelRoomDTO()
                {
                    HotelId = room.HotelID,
                    RoomNumber = room.RoomNumber,
                    Rate = room.Rate,
                    PetFriendly = room.PetFriendly,
                    RoomId = room.RoomID,
                    Room = await _roomData.GetRoomByID(room.RoomID)

                };
                hotelRooms.Add(hotelroom);
            }
        return hotelRooms;

        }

        public Task<HotelRoomDTO> GetHotelRoomByID(int hotelId, int roomnumber)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetHotelRoomByRoomNumber(int hotelID, int RoomNumber)
        {
            throw new NotImplementedException();
        }

        public Task RemoveHotelRoom(int hotelId, int roomNumber)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotelRoom(int hotelID, HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
        //public async Task<HotelRoomDTO> GetHotelRoomByRoomNumber(int hotelID, int roomNumber)
        //{
        //    var hotelNumberRoom = await _context.HotelRooms.FindAsync(hotelID, roomNumber);
            
        //    return hotelRoom;
        //}

        //public async Task<HotelRoom> GetHotelRoomByID(int hotelId, int roomId)
        //{
        //    HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomId);
        //    return hotelRoom;
        //}

        public async Task RemoveHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(hotelId, roomNumber);
            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelRoom(int hotelID, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
    }
}

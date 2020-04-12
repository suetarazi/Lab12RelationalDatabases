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
        private IRoomsManager _rooms;
        private IHotelManager _hotels;

        public HotelRoomService(AsyncHotelsDbContext context, IRoomsManager rooms, IHotelManager hotels)
        {
            _context = context;
            _rooms = rooms;
            _hotels = hotels;
        }

        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<HotelRoomDTO> ConvertToDTO(HotelRoom hotelRoom)
        {
            HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
            {
                HotelId = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomId = hotelRoom.RoomID,
                Room = await _rooms.GetRoomByID(hotelRoom.RoomID)
            };
            return hotelRoomDTO;
        }

        public HotelRoom ConvertFromDTO(HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelID = hotelRoomDTO.HotelId,
                RoomNumber = hotelRoomDTO.RoomNumber,
                RoomID = hotelRoomDTO.RoomId,
                PetFriendly = hotelRoomDTO.PetFriendly,
                Rate = hotelRoomDTO.Rate,

                //following line requires ConvertFromDTO method for rooms
                //Room = hotelRoomDTO.Room, 

                //following line require ConvertFromDTO method for hotels
                //Hotel = await _hotels.GetHotelByID(hotelRoomDTO.HotelId)

                //once these lines are re-added, the method will need to be changed to async and return a Task<HotelRoom>
                //all references to this method will also need to be await calls
            };
            return hotelRoom;
        }

        public async Task<List<HotelRoomDTO>> GetAllHotelRooms()
        {
            var getAllHotelRooms = await _context.HotelRooms.ToListAsync();
            List<HotelRoomDTO> allHotelRooms = new List<HotelRoomDTO>();


            foreach (var hotelRoom in getAllHotelRooms)
            {
                allHotelRooms.Add(await ConvertToDTO(hotelRoom));
            }
            return allHotelRooms;
        }

        public async Task<List<HotelRoomDTO>> GetAllHotelRoomsByHotel(int hotelId)
        {
            var hotelIdRooms = await _context.HotelRooms.Where(x => x.HotelID == hotelId).ToListAsync();
            List<HotelRoomDTO> hotelRooms = new List<HotelRoomDTO>();
            foreach (var room in hotelIdRooms)
            {
                hotelRooms.Add(await ConvertToDTO(room));
            }
            return hotelRooms;
        }

        public async Task<HotelRoomDTO> GetHotelRoomByRoomNumber(int hotelID, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelID, roomNumber);
            return await ConvertToDTO(hotelRoom);
        }

        public async Task<HotelRoom> GetHotelRoomByID(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomId);
            return hotelRoom;
        }

        public async Task RemoveHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = ConvertFromDTO(await GetHotelRoomByRoomNumber(hotelId, roomNumber));
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

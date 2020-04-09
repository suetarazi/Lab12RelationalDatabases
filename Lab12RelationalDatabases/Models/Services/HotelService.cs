using Lab12RelationalDatabases.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12RelationalDatabases.Models.Interfaces;
using Lab12RelationalDatabases.DTOs;

namespace Lab12RelationalDatabases.Models.Services
{
    /// <summary>
    /// connect interface of IHotelManager
    /// </summary>
    public class HotelService : IHotelManager
    {
        /// <summary>
        /// Connect the database
        /// </summary>
        private AsyncHotelsDbContext _context;
        public HotelService(AsyncHotelsDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            //Add the newly created hotel to our database
            _context.Hotels.Add(hotel);
            //save the database
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetAllHotels() => await _context.Hotels.ToListAsync();

        public async Task<Hotel> GetHotelByID(int hotelId)
        {
            Hotel hotel = new Hotel();
            HotelDTO hoteldto = new HotelDTO();
            hotel = _context.Hotels.Find(hotelId);

            hoteldto.Name = hotel.Name;
            hoteldto.PhoneNumber = hotel.Phone;
            hoteldto.City = hotel.City;

            var hotelRoom = await _context.HotelRooms.Where(r => r.HotelID == hotelId)
                .Include(d => d.Room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(a => a.Amenities)
                .ToListAsync();

            List<HotelRoomDTO> room = new List<HotelRoomDTO>();

                foreach(var hr in hotelRoom)
                {
                    room.Add(new HotelRoomDTO
                    {
                        Rate = hr.Rate,
                        PetFriendly = hr.PetFriendly,
                        RoomNumber = hr.RoomNumber,
                        Room = new RoomDTO
                        {
                            Layout = hr.Room.Layout.ToString(),
                            Name = hr.Room.Name

                        }
                    });
                }
            //var hotel = _context.Hotels.Where(x => hotelId == x.ID)
            //    .Include(x => x.HotelRoom)
            //    .ThenInclude(x => x.Room)
            //    .ThenInclude(x => x.RoomAmenities)
            //    .ThenInclude(e => e.Amenities)
            //    .Single();
            return hotel;
        }

        public async Task UpdateHotel(int hotelId, Hotel hotel)
        {
            //update hotel by Id
            _context.Entry(hotel).State = EntityState.Modified;
            //save changes
            await _context.SaveChangesAsync();
        }
    
        // task for delete needs to be here:
        public async Task RemoveHotel(int hotelId)
        {
            Hotel hotel = await GetHotelByID(hotelId);
            _context.Hotels.Remove(hotel);
            //now to save the changes:
            await _context.SaveChangesAsync();
        }

        public Task Update(int hotelID, Hotel hotel)
        {
            throw new NotImplementedException();
        }

        Task<Hotel> IHotelManager.RemoveHotel(int hotelId)
        {
            throw new NotImplementedException();
        }
    }
}

using Lab12RelationalDatabases.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12RelationalDatabases.Models.Interfaces;

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

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelByID(int hotelId)
        {
            Hotel hotel = await _context.Hotels.FindAsync(hotelId);
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

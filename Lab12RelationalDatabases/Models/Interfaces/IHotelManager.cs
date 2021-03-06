﻿using Lab12RelationalDatabases.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public interface IHotelManager
    {
        //create a hotel

        Task<Hotel> CreateHotel(Hotel hotel);

        //update a hotel

        Task Update(int hotelID, Hotel hotel);

        //get all hotels
        Task<List<HotelDTO>> GetAllHotels();

        //get a single hotel

        Task<HotelDTO> GetHotelByID(int hotelId);

        //delete  a hotel
        Task<Hotel> RemoveHotel(int hotelId);

        //get hotelRooms for hotel

    }
}

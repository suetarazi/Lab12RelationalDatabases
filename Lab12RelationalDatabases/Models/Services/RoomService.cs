﻿using Lab12RelationalDatabases.Data;
using Lab12RelationalDatabases.DTOs;
using Lab12RelationalDatabases.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models.Services
{
    public class RoomService : IRoomsManager
    {
        private AsyncHotelsDbContext _context;
        private IAmenitiesManager _amenities;

        public RoomService(AsyncHotelsDbContext context, IAmenitiesManager amenities)
        {
            _context = context;
            _amenities = amenities;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            //add the newly created room to the db
            _context.Rooms.Add(room);
            //save to the db
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task<Room> ConvertFromDTO(RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                ID = roomDTO.Id,
                Name = roomDTO.Name,
                Layout = (Layout) Enum.Parse(typeof(Layout), roomDTO.Layout),
                RoomAmenities = await GetRoomAmenities(roomDTO.Id),
                //dont know what HotelRoom is looking for
            };
            return room;
        }

        public async Task<List<RoomDTO>> GetAllRooms()
        {
            var allRooms = await _context.Rooms.ToListAsync();
            List<RoomDTO> allDTOrooms = new List<RoomDTO>();


            foreach (var room in allRooms)
            {
                List<AmenitiesDTO> roomAmenityDTO = await GetAmenities(room.ID);
                var roomDTO = new RoomDTO()
                {
                    Id = room.ID,
                    Name = room.Name,
                    Layout = room.Layout.ToString(),
                    Amenities = roomAmenityDTO
                };
                allDTOrooms.Add(roomDTO);
            
            }
            return allDTOrooms;
        }

        //
        //make a call out to bring in amenities interface
        //make a new list
        //

        public async Task<RoomDTO> GetRoomByID(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            List<AmenitiesDTO> roomAmenityDTO = new List<AmenitiesDTO>();
            foreach(var amenity in room.RoomAmenities)
            {
                var getAmenities = new AmenitiesDTO
                {
                    ID = amenity.ID,
                    Name = _context.Amenities.Find(amenity.AmenitiesID).Name,
                };
                roomAmenityDTO.Add(getAmenities);
            }

            RoomDTO roomDto = new RoomDTO
            {
                Id = room.ID,
                Name = room.Name,
                Layout = room.Layout.ToString(),
                Amenities = roomAmenityDTO
            };
            return roomDto;
        }

        public async Task UpdateRoom(int roomId, Room room)
        {
            //set room equal to the one passed in
            _context.Entry(room).State = EntityState.Modified;

            //save changes
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRoom(int roomId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);

              _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
    }

        public async Task<List<AmenitiesDTO>> GetAmenities(int roomId)
        {
            // getting all of the RoomAmenities where roomid == roomid
            // return a list RoomAmentities Objects
            var roomAmenities = await _context.RoomAmenities.Where(x => x.RoomID == roomId ).ToListAsync();

            // traverse over my amenities and get the individual details about each amentity. 
            List<AmenitiesDTO> amenitiesResults = new List<AmenitiesDTO>();

            foreach (var item in roomAmenities)
            {
                var items = await _amenities.GetAmenitiesByID(item.AmenitiesID);
                amenitiesResults.Add(items);
            }
            // Bring in your IAmenityManager into this service
            // in your foreach loop, you are going to call the _amenities.getamentitiesbyid(item.amenitiesId) method.
            // the returnedresult will be put into a list and returned.
            return amenitiesResults;
        }

        public async Task<List<RoomAmenities>> GetRoomAmenities(int roomId)
        {
            var roomAmenities = await _context.RoomAmenities.Where(roomAmenities => roomAmenities.RoomID == roomId)
                .ToListAsync();
            foreach(var roomAmenity in roomAmenities)
            {
                roomAmenity.Amenities = await _context.Amenities.FindAsync(roomAmenity.AmenitiesID);
            }
            return roomAmenities;
        }

        Task<List<AmenitiesDTO>> IRoomsManager.GetRoomAmenities(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12RelationalDatabases.Models;

namespace Lab12RelationalDatabases.Data
{
    public class AsyncHotelsDbContext : DbContext
    {
        public AsyncHotelsDbContext(DbContextOptions<AsyncHotelsDbContext> options) : base (options)
        {
            
        }

        //Declare certain keys as foreign keys
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelID, x.RoomID });
            modelBuilder.Entity<RoomAmenities>().HasKey(ra => new { ra.AmenitiesID, ra.RoomID });

            //Seeding data for Hotel table
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Seattle Async",
                    StreetAddress = "443 3rd Ave",
                    City = "Seattle",
                    State = "Washington",
                    Phone = "206-555-4509"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Maui Async",
                    StreetAddress = "445 Ka'anapali Blvd",
                    City = "Maui",
                    State = "Hawaii",
                    Phone = "808-555-4510"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Dubuque Async",
                    StreetAddress = "447 7th Ave",
                    City = "Dubuque",
                    State = "Iowa",
                    Phone = "563-555-4511"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Steamboat Springs Async",
                    StreetAddress = "449 9th Ave",
                    City = "Steamboat Springs",
                    State = "Colorado",
                    Phone = "970-555-4513"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Santa Monica Async",
                    StreetAddress = "451 Santa Monica Blvd",
                    City = "Santa Monica",
                    State = "California",
                    Phone = "310-555-4509"
                }
                );

            //seeding table for Room table
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Studio",
                    Layout = (Layout)0
                },
                new Room
                {
                    ID = 2,
                    Name = "One Bedroom",
                    Layout = (Layout)1
                },
                new Room
                {
                    ID = 3,
                    Name = "Two Bedroom",
                    Layout = (Layout)2
                },
                new Room
                {
                    ID = 4,
                    Name = "Studio (ADA Compliant)",
                    Layout = (Layout)3
                },
                new Room
                {
                    ID = 5,
                    Name = "One Bedroom (ADA Compliant)",
                    Layout = (Layout)4
                },
                new Room
                {
                    ID = 6,
                    Name = "Two Bedroom (ADA Compliant)",
                    Layout = (Layout)5
                }
                );

            //seeding data for Amenities table
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Minifridge"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Minibar"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Balcony"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Waterfront View"
                }
                );

            //seeding table for HotelRoom join table with payload
            //modelBuilder.Entity<HotelRoom>().HasData(
            //    new HotelRoom
            //    {
            //        HotelID = 1,
            //        RoomID = 2,
            //        RoomNumber = 503,
            //        Rate = 200,
            //        PetFriendly = true
            //    },
            //    new HotelRoom
            //    {
            //        HotelID = 3,
            //        RoomID = 1,
            //        RoomNumber = 404,
            //        Rate = 180,
            //        PetFriendly = false
            //    }
            //    );
        }

        //Refer to each table created
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

    }
}

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
        }

        //Refer to each table created
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

    }
}

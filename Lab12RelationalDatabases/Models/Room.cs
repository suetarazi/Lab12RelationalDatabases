using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class Room
    {
        public Layout Layout { get; set; }

        public List<RoomAmenities> RoomAmenities { get; set; }
        public List<HotelRoom> HotelRoom { get; set; }
    }


    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}

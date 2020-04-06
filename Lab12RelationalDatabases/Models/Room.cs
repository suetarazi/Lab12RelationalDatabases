using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class Room
    {

        public int ID { get; set; }

        public string Name { get; set; }
        
        //Refers to enum below for layout types
        public Layout Layout { get; set; }

        //Navigation properties
        public List<RoomAmenities> RoomAmenities { get; set; }
        public List<HotelRoom> HotelRoom { get; set; }
    }

    //This is the Enum for the Layout property above
    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom,
        StudioADA,
        OneBedroomADA,
        TwoBedroomADA
    }
}

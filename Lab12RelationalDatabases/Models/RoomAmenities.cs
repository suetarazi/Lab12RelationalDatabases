using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class RoomAmenities
    {
        public int RoomID { get; set; }
        public string AmenitiesID { get; set; }
    
        //Nav props

        public Room Room { get; set; }
        public Amenities Amenities { get; set; }
    }

    
}

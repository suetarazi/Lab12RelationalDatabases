using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class RoomAmenities
    {
        public string AmenitiesID { get; set; }
        public int RoomID { get; set; }
    
     
        //Navigation properties

        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }

    
}

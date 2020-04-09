using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class RoomAmenities
    {
        //Composite keys as well as Foreign keys
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }
     
        //Navigation properties
        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
        public int ID { get; internal set; }
    }
}

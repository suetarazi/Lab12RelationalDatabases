using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.DTOs
{
    public class HotelDTO
    {
        public string Name { get; set; }
    
        public string StreetAddress { get; set; }

        public string City { get; set; }
    
        public string State { get; set; }
    
        public string PhoneNumber { get; set; }

        public List<HotelRoomDTO> Rooms { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.DTOs
{
    public class HotelRoomDTO
    {
        public int RoomNumber { get; set; }

        public decimal Rate { get; set; }

        public bool PetFriendly { get; set; }

        public RoomDTO Room { get; set; }
    
    }
}

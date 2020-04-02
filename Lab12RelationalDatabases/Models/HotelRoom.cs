using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class HotelRoom
    {
        //composite key
            public int HotelID { get; set; }

            public int RoomNumber { get; set; }

            //regular table info
            public int RoomID { get; set; }

            public bool PetFriendly { get; set; }

            public decimal Rate { get; set; }


        //navigation - has 2 foreign keys
         public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}

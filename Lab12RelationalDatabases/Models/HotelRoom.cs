using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class HotelRoom
    {
        //composite key
        int HotelID

            int RoomID

            //regular table info?
            int RoomNumber

            bool PetFriendly

            decimal Rate

    }

    //navigation - has 2 foreign keys
    public Hotel Hotel { get; set; }
    public Room Room { get; set; }
}

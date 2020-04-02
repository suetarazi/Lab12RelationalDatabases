using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Phone { get; set; }



        //Navigation Property: HotelRoom

        public HotelRoom HotelRoom { get; set; }
    }
}

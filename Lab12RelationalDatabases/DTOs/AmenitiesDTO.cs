using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.DTOs
{
    public class AmenitiesDTO
    {
        // not incorrect to include ID, but it is not required. It adds more work for the end user to have it
        //public int ID { get; set; }
        public string Name { get; set; }

    }
}

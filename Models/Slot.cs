using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class Slot
    {
        public string name { get; set; }
        public Boolean isOccupied { get; set; }

        public string category;

        public Slot(string name, bool occupied, string category)
        {
            this.name = name;
            this.isOccupied = occupied;
            this.category = category;

        }
    }
}

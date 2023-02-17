using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    abstract class Vechile
    {
        public string number { get; set; }
        public string category { get; set; }
        public Vechile(string number)
        {
            this.number = number;
        }
    }
}

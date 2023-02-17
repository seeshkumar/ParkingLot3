using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class FourWheelerVechile : Vechile
    {
        public FourWheelerVechile(string number) : base(number)
        {
            this.category = "FOURWHEELER";
        }
    }
}

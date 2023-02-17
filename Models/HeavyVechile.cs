using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    internal class HeavyVechile : Vechile
    {
        public HeavyVechile(string number) : base(number)
        {
            this.category = "HEAVY";
        }
    }
}

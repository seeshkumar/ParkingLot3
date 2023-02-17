using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class NewVechile : Vechile
    {
        public NewVechile(string number) : base(number)
        {
            this.category = "NEW";
        }
    }
}

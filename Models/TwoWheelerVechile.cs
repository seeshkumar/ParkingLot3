using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using ParkingLot.Models;

namespace ParkingLot.Models
{
    class TwoWheelerVechile : Vechile
    {

        public TwoWheelerVechile(string number) : base(number)
        {
            this.category = "TWOWHEELER";
        }
    }
}

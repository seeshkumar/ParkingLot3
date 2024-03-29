﻿using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface IDriveVechileService
    {
        public string ParkVechile(List<Slot> slots, Vechile vechile);
        public string UnParkVechile(List<Slot> slots, string number);

    }
}

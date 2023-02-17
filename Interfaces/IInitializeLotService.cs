using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface IInitializeLotService
    {
        public List<Slot> InitializeLot(Injector injector, int twoWheelerSlots, int fourWheelerSlots, int heavyVechileSlots);

    }
}

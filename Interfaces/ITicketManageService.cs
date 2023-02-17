using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface ITicketManageService
    {
        public Ticket GenerateTicket(Slot freeSlot, Vechile vechile);
        public void DeleteTicket(List<Ticket> tickets, Ticket ticket);


    }

}

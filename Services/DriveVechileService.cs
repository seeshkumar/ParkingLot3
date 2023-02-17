using ParkingLot.Injectors;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    class DriveVechileService : IDriveVechileService
    {
        public string ParkVechile(Injector injector, List<Slot> slots, Vechile vechile)
        {
                        Slot freeSlot = slots.FirstOrDefault(s => s.category == vechile.category && s.isOccupied == false);
                        if (freeSlot == null)
                        {
                            return "No slots available";
                        }

                        freeSlot.isOccupied = true;
                        injector.SaveSlots(slots);
                        Ticket ticket = injector.GenerateTicket(freeSlot, vechile);
                        //ticket string
                        return $"VECHILE NUMBER : {ticket.vechileNumber} \nSLOT NAME : {ticket.slotName} \nIN TIME : {ticket.inTime} \nOUT TIME : -";
                    
            //return "parkvechilefunc";
            }

        public string UnParkVechile(Injector injector, List<Slot> slots, string number)
        {

            List<Ticket> tickets = injector.ReadTickets();

            Ticket ticket = tickets.FirstOrDefault(t => t.vechileNumber == number);
            if (ticket == null)
            {
                return "Vechile not found";
            }
            slots.FirstOrDefault(s => s.name == ticket.slotName).isOccupied = false;
            injector.SaveSlots(slots);

            DateTime outTime = DateTime.Now;
            string msg = $"VECHILE NUMBER : {ticket.vechileNumber} \nSLOT NAME : {ticket.slotName} \nIN TIME : {ticket.inTime} \nOUT TIME : {outTime}";

            injector.DeleteTicket(tickets, ticket);

            return msg;
        }

    }
}

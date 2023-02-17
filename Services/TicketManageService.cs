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
    class TicketManageService : ITicketManageService
    {
        TicketsFileService ticketsFileService;
        public TicketManageService(TicketsFileService ticketsFileService) 
        {
            this.ticketsFileService = ticketsFileService;
        }
        public Ticket GenerateTicket(Slot freeSlot, Vechile vechile)
        {
            List<Ticket> tickets = ticketsFileService.ReadTickets();
            DateTime inTime = DateTime.Now;
            Ticket ticket = new Ticket(freeSlot.name, vechile.number, inTime);
            tickets.Add(ticket);
            ticketsFileService.SaveTickets(tickets);
            return ticket;
        }

        public void DeleteTicket(List<Ticket> tickets, Ticket ticket)
        {
            if(tickets.Contains(ticket))
                tickets.Remove(ticket);
            ticketsFileService.SaveTickets(tickets);
        }

    }

}

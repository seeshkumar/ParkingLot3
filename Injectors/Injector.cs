using ParkingLot.Interfaces;
using ParkingLot.Services;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Models;
using System.Net.Sockets;



namespace ParkingLot.Injectors
{
    class Injector
    {
        // public IParkingLotService parkingLotService;
        //public ITicketService ticketService;


        public ParkingSlotsFileService parkingSlotsFileService;
        public IInitializeLotService initializeLotService;
        public IDriveVechileService driveVechileService;

        public TicketsFileService ticketsFileService;
        public ITicketManageService ticketManageService;

        

        public Injector(ParkingSlotsFileService parkingSlotsFileService, IInitializeLotService initializeLotService, IDriveVechileService driveVechileService, TicketsFileService ticketsFileService, ITicketManageService ticketManageService)
        {
            this.parkingSlotsFileService = parkingSlotsFileService;
            this.initializeLotService = initializeLotService;
            this.driveVechileService = driveVechileService;

            this.ticketsFileService = ticketsFileService;
            this.ticketManageService = ticketManageService;
        }



        // ParkingLotService methods
        public List<Slot> ReadSlots()
        {
            return parkingSlotsFileService.ReadSlots();
        }

        public Boolean SaveSlots(List<Slot> slots)
        {
            return parkingSlotsFileService.SaveSlots(slots);
        }

        public List<Slot> InitializeLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVechileSlots)
        {
            return initializeLotService.InitializeLot(this, twoWheelerSlots, fourWheelerSlots, heavyVechileSlots);
        }

        public string ParkVechile(List<Slot> slots, Vechile vechile)
        {
            return driveVechileService.ParkVechile(this, slots, vechile);
        }

        public string UnParkVechile(List<Slot> slots, string number)
        {
            return driveVechileService.UnParkVechile(this, slots, number);
        }



        ///TicketService methods
        public List<Ticket> ReadTickets()
        {
            return ticketsFileService.ReadTickets();
        }
        public Boolean SaveTickets(List<Ticket> tickets)
        {
            return ticketsFileService.SaveTickets(tickets);
        }
        public Ticket GenerateTicket(Slot freeSlot, Vechile vechile)
        {
            return ticketManageService.GenerateTicket(this, freeSlot, vechile);
        }
        public void DeleteTicket(List<Ticket> tickets, Ticket ticket)
        {
            ticketManageService.DeleteTicket(this, tickets, ticket);
        }

    }
}

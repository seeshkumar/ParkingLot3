﻿using ParkingLot.Injectors;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    class InitializeLotService : IInitializeLotService
    {
        ParkingSlotsFileService parkingSlotsFileService;
        TicketsFileService ticketsFileService;
        public InitializeLotService(ParkingSlotsFileService parkingSlotsFileService,TicketsFileService ticketsFileService)
        {
            this.parkingSlotsFileService = parkingSlotsFileService;
            this.ticketsFileService = ticketsFileService;
        }

        public List<Slot> InitializeLot(int twoWHEELERSlots, int fourWHEELERSlots, int heavyVechileSlots)
        {


            List<Slot> slots = new List<Slot>();
            string name;

            for (int index = 0; index < twoWHEELERSlots; index++)
            {
                name = $"TWO{index + 1}";
                slots.Add(new Slot(name, false, "TWOWHEELER"));
            }

            for (int index = 0; index < fourWHEELERSlots; index++)
            {
                name = $"FOUR{index + 1}";
                slots.Add(new Slot(name, false, "FOURWHEELER"));
            }

            for (int index = 0; index < heavyVechileSlots; index++)
            {
                name = $"HEAVY{index + 1}";
                slots.Add(new Slot(name, false, "HEAVY"));
            }
            parkingSlotsFileService.SaveSlots(slots);
            ticketsFileService.SaveTickets(new List<Ticket>());//clearing tickets db
            return slots;
        }

    }
}

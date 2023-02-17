using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface ITicketFileService
    {
        public List<Ticket> ReadTickets();
        public Boolean SaveTickets(List<Ticket> tickets);


    }

}

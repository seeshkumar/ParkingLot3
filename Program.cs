using ParkingLot.Injectors;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using ParkingLot.Services;
using System.Runtime.CompilerServices;

class Program
{
    public static void Main(String[] args)
    {
        int mode;
        
        ParkingSlotsFileService parkingSlotsFileService = new ParkingSlotsFileService();
        IInitializeLotService initializeLotService = new InitializeLotService();
        IDriveVechileService driveVechileService = new DriveVechileService();

        TicketsFileService ticketsFileService = new TicketsFileService();
        ITicketManageService ticketManageService = new TicketManageService();

        Injector injector = new Injector(parkingSlotsFileService, initializeLotService, driveVechileService, ticketsFileService, ticketManageService);
        
        List<Slot> slots;
        List<Ticket> tickets;
        string number;
        string category;
        string msg;
        bool endProgram = false;
        while (!endProgram)
        {
            Console.WriteLine("\n\n1.Initialize a parking lot.\n2.See Parking Lot current occupancy details.\n3.Park Vehicle and Issue Ticket.\n4.Un-park Vehicle.\n5.End   :");
            mode = Convert.ToInt32(Console.ReadLine());


            switch (mode)
            {
                case 1:
                    Console.WriteLine("-------- Initializing Lot --------");
                    Console.Write("Number of 2 wheeler slots : ");
                    int twoWheelerSlots = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Number of 4 wheeler slots : ");
                    int fourWheelerSlots = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Number of heavy vechile slots : ");
                    int heavyVechileSlots = Convert.ToInt32(Console.ReadLine());
                    slots = injector.InitializeLot(twoWheelerSlots, fourWheelerSlots, heavyVechileSlots);
                    Console.WriteLine("Initialized Slots");
                    break;
                case 2:
                    slots = injector.ReadSlots();
                    tickets = injector.ReadTickets();
                    foreach (Slot slot in slots)
                    {
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine($"SLOT : {slot.name}\nSLOT CATEGORY : {slot.category}");
                        if (slot.isOccupied == false)
                        {
                            Console.WriteLine("-- EMPTY SLOT --");
                        }
                        else
                        {
                            Console.WriteLine($"OCCUPIED BY : {tickets.FirstOrDefault(t => t.slotName == slot.name).vechileNumber}");
                        }
                        Console.WriteLine("--------------------------------------");
                    }
                    break;
                case 3:
                    slots = injector.ReadSlots();
                    Console.Write("Vechile number : ");
                    number = Console.ReadLine();
                    Console.WriteLine("Category(TWOWHEELER/ FOURWHEELER/ HEAVY) :");
                    category = Console.ReadLine();
                    msg = "Could not park vechile.";
                    if(category == "TWOWHEELER")
                    {
                        msg = injector.ParkVechile(slots, new TwoWheelerVechile(number));
                    }
                    else if(category == "FOURWHEELER")
                    {
                        msg = injector.ParkVechile(slots, new FourWheelerVechile(number));
                    }
                    else if(category == "HEAVY")
                    {
                        msg = injector.ParkVechile(slots, new HeavyVechile(number));
                    }
                    Console.WriteLine("----------- TICKET -----------");
                    Console.WriteLine(msg);
                    Console.WriteLine("------------------------------");
                    break;
                case 4:
                    slots = injector.ReadSlots();
                    Console.Write("Vechile number : ");
                    number = Console.ReadLine();
                    msg = injector.UnParkVechile(slots, number);
                    Console.WriteLine("----------- TICKET -----------");
                    Console.WriteLine(msg);
                    Console.WriteLine("------------------------------");
                    break;
                case 5:
                    endProgram = true;
                    break;
                default:
                    break;

            }

            
        }







    }
}

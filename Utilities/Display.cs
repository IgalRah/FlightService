using System;
using FlightService.DAL;
using FlightService.Model;

namespace FlightService.Utilities
{
    public class Display
    {
        private static IFlightRepository _flightRepository;
        public Display(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public static void StartMenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFlight Booking: \n");
            Console.ResetColor();

            Console.WriteLine("1. Purchase a ticket");
            Console.WriteLine("2. Watch all flights");
            Console.WriteLine("0. Close App");
        }

        public static void MainMenu()
        {
            Console.Write("\nChoose flight by Id Number: ");
            var chooseFlight = Console.ReadLine();


            switch (chooseFlight)
            {
                case "1":
                    {
                        Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                        var amontOfTickets = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Baggage weight: ");
                        var weightOfBag = int.Parse(Console.ReadLine());

                        if (weightOfBag <= 12)
                        {
                            //_flightRepository.InsertDataToBooking(new Booking { NumberOfBags = 1, BaggageWeight = weightOfBag });
                            Success(amontOfTickets);
                            break;
                        }
                        else
                        {
                            Failure();
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                        var amontOfTickets = Int32.Parse(Console.ReadLine());

                        Console.WriteLine($"Baggage amount: ");
                        var amountOfBag = Int32.Parse(Console.ReadLine());

                        Console.WriteLine($"Baggage weight: ");
                        var weightOfBag = Int32.Parse(Console.ReadLine());

                        if (weightOfBag <= 15)
                        {
                            // _flightReposetary.InsertDataToBooking(new Model.Booking { NumberOfBags = amountOfBag, BaggageWeight = weightOfBag });
                            Success(amontOfTickets);
                        }
                        else
                        {
                            Failure();
                        }
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                        var amontOfTickets = Int32.Parse(Console.ReadLine());

                        Console.WriteLine($"Baggage amount: ");
                        var amountOfBag = Int32.Parse(Console.ReadLine());

                        Console.WriteLine($"Baggage weight: ");
                        var weightOfBag = Int32.Parse(Console.ReadLine());

                        if (weightOfBag <= 10)
                        {
                            //_flightReposetary.InsertDataToBooking(new Model.Booking { NumberOfBags = amountOfBag, BaggageWeight = weightOfBag });
                            Success(amontOfTickets);
                        }
                        else
                        {
                            Failure();
                        }
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                        var amountOfTickets = Int32.Parse(Console.ReadLine());

                        Console.WriteLine($"Baggage weight: ");
                        var weightOfBag = Int32.Parse(Console.ReadLine());

                        if (weightOfBag <= 20)
                        {
                            //_flightReposetary.InsertDataToBooking(new Model.Booking { NumberOfBags = 1, BaggageWeight = weightOfBag });
                            Success(amountOfTickets);
                        }
                        else
                        {
                            Failure();
                        }
                        break;
                    }
            }
        }
         
        public static void Success(int amount)
        {
            var infoAbotFlight = _flightRepository.GetAllFlights();
            infoAbotFlight.ForEach(info => Console.WriteLine($"Summery: \n" +
                $"Destination: TLV => {info.Destination},Tickets: {amount}, Paggages: {info.MaxBagsPerPassenger}\n" +
                $"Press Enter to purchase"));

            Console.ReadLine();

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Success");
            Console.ResetColor();
        }
        public static void Failure()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Baggage is over weight!");
            Console.ResetColor();
        }
    }
}

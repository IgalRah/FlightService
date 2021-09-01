using System;
using FlightService.DAL;
using FlightService.Utilities;
using FlightService.Model;

namespace FlightService
{
    public class EntryPoint
    {
        private static IFlightRepository _flightRepository;
        public EntryPoint(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public void Run()
        {
            Display.StartMenu();

            var option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "0":
                    Environment.Exit(1);
                    break;

                case "1":
                    {
                        Console.WriteLine("\nEnter your name: ");
                        var name = Console.ReadLine();

                        Console.WriteLine($"\nWelcome {name}!");

                        //_flightRepository.InsertDataToPassanger(new Model.Passenger { Name = name });
                    }
                    break;

                case "2":
                    {
                        var items = _flightRepository.GetAllFlights();
                        items.ForEach(item =>
                        { Console.WriteLine($"TLV => {item.Destination}"); });
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Wrong Input!");
                        break;
                    }
            }

            if (option == "1")
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nFlights Details: \n");
                Console.ResetColor();

                var flightsToShow = _flightRepository.GetAllFlights();
                flightsToShow.ForEach(flight =>
                { Console.WriteLine($"[{flight.Id}] {flight.Destination}:\n{flight.MaxBagsPerPassenger} Bag of {flight.MaxBaggageWeightPerPassenger} Kg || No more than 10 tickets\n"); });


                Console.Write("\nChoose flight by Id Number: ");
                var chooseFlight = int.Parse(Console.ReadLine());

                while (true)
                {
                    switch (chooseFlight)
                    {
                        case 1:
                            {
                                Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                                var amontOfTickets = int.Parse(Console.ReadLine());

                                Console.WriteLine($"Baggage weight: ");
                                var weightOfBag = int.Parse(Console.ReadLine());

                                if (weightOfBag <= 12 && amontOfTickets <= 10)
                                {
                                    _flightRepository.InsertDataToBooking(new Booking {FlightId = chooseFlight, NumberOfBags = 1, BaggageWeight = weightOfBag });
                                    Success(amontOfTickets, chooseFlight);
                                    Environment.Exit(1);
                                }
                                else
                                {
                                    Failure();
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                                var amontOfTickets = int.Parse(Console.ReadLine());

                                Console.WriteLine($"Baggage amount: ");
                                var amountOfBag = int.Parse(Console.ReadLine());

                                Console.WriteLine($"Baggage weight: ");
                                var weightOfBag = int.Parse(Console.ReadLine());

                                if (weightOfBag <= 15 && amontOfTickets <= 10 && amountOfBag <= 2)

                                {
                                    _flightRepository.InsertDataToBooking(new Model.Booking { FlightId = chooseFlight, NumberOfBags = amountOfBag, BaggageWeight = weightOfBag });
                                    Success(amontOfTickets, chooseFlight);
                                    Environment.Exit(1);
                                }
                                else
                                {
                                    Failure();
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                                var amontOfTickets = int.Parse(Console.ReadLine());

                                Console.WriteLine($"Baggage amount: ");
                                var amountOfBag = int.Parse(Console.ReadLine());

                                Console.WriteLine($"Baggage weight: ");
                                var weightOfBag = int.Parse(Console.ReadLine());

                                if (weightOfBag <= 10 && amontOfTickets <= 10 && amountOfBag <= 2)

                                {
                                    _flightRepository.InsertDataToBooking(new Model.Booking { FlightId = chooseFlight, NumberOfBags = amountOfBag, BaggageWeight = weightOfBag });
                                    Success(amontOfTickets, chooseFlight);
                                    Environment.Exit(1);
                                }
                                else
                                {
                                    Failure();
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"\nAmount of tickets you'd like to purchase: ");
                                var amontOfTickets = int.Parse(Console.ReadLine());

                                Console.WriteLine($"Baggage weight: ");
                                var weightOfBag = int.Parse(Console.ReadLine());

                                if (weightOfBag <= 20 && amontOfTickets <= 10)

                                {
                                    _flightRepository.InsertDataToBooking(new Model.Booking { FlightId = chooseFlight, NumberOfBags = 1, BaggageWeight = weightOfBag });
                                    Success(amontOfTickets, chooseFlight);
                                    Environment.Exit(1);
                                }
                                else
                                {
                                    Failure();
                                }
                                break;
                            }
                    }
                }
            }
            else
            {
                Run();
            }
        }
        static void Success(int amount, int idFlight)
        {
            var infoAbotFlight = _flightRepository.GetFlightById(idFlight);

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nSummery: ");
            Console.ResetColor();

            Console.WriteLine($"Destination: TLV => {infoAbotFlight.Destination}, Tickets: {amount}, Paggage: {infoAbotFlight.MaxBagsPerPassenger} \n" +
                $"Press Enter to Purchase or '0' to Exit");

            var answer = Console.ReadLine();
            if (answer == "0")
            {
                Environment.Exit(0);
            }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Payment Succeeded");
            Console.ResetColor();
        }
        static void Failure()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The data you entered does not match the requests!");
            Console.ResetColor();
        }
    }
}

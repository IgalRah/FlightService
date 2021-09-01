using System;
using FlightService.DAL;
using FlightService.Utilities;

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
                    Environment.Exit(0);
                    break;

                case "1":
                    {
                        Console.WriteLine("\nEnter your name: ");
                        var name = Console.ReadLine();

                        Console.WriteLine($"\nWelcome {name}!");

                        //_flightReposetary.InsertDataToPassanger(new Model.Passenger {Name = name });
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
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\nFlights Details: \n");
                Console.ResetColor();

                var flightsToShow = _flightRepository.GetAllFlights();
                flightsToShow.ForEach(flight =>
                { Console.WriteLine($"[{flight.Id}] {flight.Destination}:\nBHS = {flight.MaxBagsPerPassenger} Bag of {flight.MaxBaggageWeightPerPassenger} Kg\n"); });

                Display.MainMenu();
            }
            else
            {
                Run();
            }
        }
    }
}

using System;
using FlightService.DAL;
using FlightService.Model;

namespace FlightService
{
    public class EntryPoint
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IPassengerRepository _passengerRepository;

        public EntryPoint(IFlightRepository flightRepository, IBookingRepository bookingRepository, IPassengerRepository passengerRepository)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
            _passengerRepository = passengerRepository;
        }

        public void Run()
        {
            TextColor("\nFlight Booking\n", ConsoleColor.Blue);

            Console.WriteLine("1. Book a flight");
            Console.WriteLine("2. List flights");
            Console.WriteLine("0. Close App");

            Console.Write("\nOption: ");
            var option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "0":
                    break;

                case "1":
                    {
                        Console.Write("Enter your name: ");
                        var name = Console.ReadLine();

                        Console.WriteLine($"\nWelcome {name}!");

                        var passenger = new Passenger { Name = name };
                        _passengerRepository.CreatePassenger(passenger);

                        UserMenu(passenger);
                    }
                    break;

                case "2":
                    {
                        var items = _flightRepository.GetAllFlights();
                        items.ForEach(item => Console.WriteLine($"TLV => {item.Destination}"));

                        Run();
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Wrong Input!");
                        Run();
                        break;
                    }
            }
        }

        private void UserMenu(Passenger passenger)
        {
            TextColor("\nFlights Details\n", ConsoleColor.Magenta);

            var flightsToShow = _flightRepository.GetAllFlights();
            flightsToShow.ForEach(flight => Console.WriteLine($"[{flight.FlightId}]: TLV => {flight.Destination}"));

            var flightId = ReadAndParseInt("\nChoose flight by Id: ");

            var flight = _flightRepository.GetFlightById(flightId);

            if (flight == null)
            {
                TextColor("\nFlight not exists!", ConsoleColor.DarkRed);
                UserMenu(passenger);
                return;
            }

            Console.WriteLine($"\n{flight.MaxBagsPerPassenger} Bag of {flight.MaxBaggageWeightPerPassenger} Kg (total)\n");

            int amountOfBag;
            while (true)
            {
                amountOfBag = ReadAndParseInt("Baggage amount: ");

                if (amountOfBag <= flight.MaxBagsPerPassenger) break;
                else TextColor("\nInvalid amount of baggage!", ConsoleColor.DarkRed);
            }

            int? weightOfBag = null;
            while (amountOfBag > 0)
            {
                weightOfBag = ReadAndParseInt("Baggage weight (total): ");

                if (weightOfBag <= flight.MaxBaggageWeightPerPassenger) break;
                else TextColor("\nThe baggage is over weight!", ConsoleColor.DarkRed);
            }

            var booking = new Booking
            {
                Flight = flight,
                NumberOfBags = amountOfBag,
                BaggageWeight = weightOfBag,
                Passenger = passenger,
            };
            _bookingRepository.CreateBooking(booking);

            Checkout(booking);

            Console.ReadLine();
        }

        void Checkout(Booking booking)
        {
            Console.WriteLine();
            TextColor("Summary", ConsoleColor.DarkYellow);

            Console.WriteLine($"Destination: TLV => {booking.Flight.Destination}\nBaggage: {booking.NumberOfBags}\n");

            Console.WriteLine("Press Enter to book or any other key to cancel");

            if (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                TextColor("\nOrder has been canceled", ConsoleColor.DarkRed);
                return;
            }

            TextColor("\nBooking succeeded", ConsoleColor.DarkGreen);
        }

        static void TextColor(string str, ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        static int ReadAndParseInt(string prompt)
        {
            Console.Write(prompt);

            try
            {
                var number = int.Parse(Console.ReadLine());
                return number;
            }
            catch
            {
                TextColor("\nInvalid input!", ConsoleColor.DarkRed);
                return ReadAndParseInt(prompt);
            }
        }
    }
}

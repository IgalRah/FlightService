using System;
using FlightService.DAL;

namespace FlightService.Utilities
{
    public class Display
    {
        public static void StartMenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFlight Booking: \n");
            Console.ResetColor();

            Console.WriteLine("1. Purchase a ticket");
            Console.WriteLine("2. Watch all flights");
            Console.WriteLine("0. Close App");
        }
    }
}

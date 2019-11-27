using Aircompany.Data;
using Aircompany.Planes;
using System;
using System.Collections.Generic;

namespace Aircompany
{
    public class Runner
    {
        public static List<Plane> Planes { get; private set; } = new List<Plane>();

        public static void Main(string[] args)
        {
            Planes = AirportPlanes.Planes;

            MixedAirport airport = new MixedAirport { Planes = Planes };

            MilitaryAirport militaryAirport = new MilitaryAirport { Planes = airport.GetMilitaryPlanes() };

            PassengerAirport passengerAirport = new PassengerAirport { Planes = airport.GetPassengersPlanes() };

            Console.WriteLine(militaryAirport.SortByMaxDistance().ToString());
            Console.WriteLine(passengerAirport.SortByMaxSpeed().ToString());
            Console.WriteLine(passengerAirport.GetPlaneWithMaxPassengersCapacity());

            Console.ReadKey();
        }
    }
}

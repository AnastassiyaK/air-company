using Aircompany;
using Aircompany.Data;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private static List<Plane> planes;

        private static PassengerPlane planeWithMaxPassengerCapacity = new PassengerPlane
        {
            Model = "Boeing-747",
            MaxSpeed = 980,
            MaxFlightDistance = 16100,
            MaxLoadCapacity = 70500,
            PassengersCapacity = 242
        };

        [OneTimeSetUp]
        public void SetUp()
        {
            planes = AirportPlanes.Planes;
        }

        [Test]
        public void MyTest1()
        {
            MixedAirport airport = new MixedAirport
            {
                Planes = planes
            };
            List<MilitaryPlane> transportMilitaryPlanes = airport.GetTransportMilitaryPlanes();
            bool hasMilitaryTransportPlane = false;

            foreach (MilitaryPlane militaryPlane in transportMilitaryPlanes)
            {
                if ((militaryPlane.Type == MilitaryType.TRANSPORT))
                {
                    hasMilitaryTransportPlane = true;
                }
            }

            Assert.IsTrue(hasMilitaryTransportPlane);
        }

        [Test]
        public void MyTest2()
        {
            MixedAirport airport = new MixedAirport
            {
                Planes = planes
            };

            PassengerAirport passengerAirport = new PassengerAirport
            {
                Planes = airport.GetPassengersPlanes()
            };

            PassengerPlane expectedPlaneWithMaxPassengersCapacity = passengerAirport.GetPlaneWithMaxPassengersCapacity();

            Assert.That(planeWithMaxPassengerCapacity, Is.EqualTo(expectedPlaneWithMaxPassengersCapacity));
        }

        [Test]
        public void MyTest3()
        {
            MixedAirport airport = new MixedAirport
            {
                Planes = planes
            };

            var allPlanes = airport.GetSortedPlanesByMaxLoadCapacity();

            bool nextPlaneMaxLoadCapacityIsHigherThanCurrent = true;
            for (int i = 0; i < allPlanes.Count - 1; i++)
            {
                Plane currentPlane = allPlanes[i];
                Plane nextPlane = allPlanes[i + 1];

                if (currentPlane.MaxLoadCapacity > nextPlane.MaxLoadCapacity)
                {
                    nextPlaneMaxLoadCapacityIsHigherThanCurrent = false;
                }
            }

            Assert.That(nextPlaneMaxLoadCapacityIsHigherThanCurrent == true);
        }
    }
}

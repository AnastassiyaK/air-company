using Aircompany;
using Aircompany.Data;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
        public void CheckTransportMilitaryPlanesOnly()
        {
            MixedAirport airport = new MixedAirport { Planes = planes };

            var actualTransportMilitaryPlanes = airport.GetTransportMilitaryPlanes();

            var expectedPlanes = actualTransportMilitaryPlanes.Where(p => p.IsTransport()).ToList();

            CollectionAssert.AreEquivalent(actualTransportMilitaryPlanes, expectedPlanes);
        }

        [Test]
        public void ComparePlanesWithMaxPassengerCapacity()
        {
            MixedAirport airport = new MixedAirport { Planes = planes };

            PassengerAirport passengerAirport = new PassengerAirport { Planes = airport.GetPassengersPlanes() };

            PassengerPlane expectedPlaneWithMaxPassengersCapacity = passengerAirport.GetPlaneWithMaxPassengersCapacity();

            Assert.That(planeWithMaxPassengerCapacity, Is.EqualTo(expectedPlaneWithMaxPassengersCapacity));
        }

        [Test]
        public void CheckSortInAirportByMaxLoadCapacity()
        {
            var allPlanes = new MixedAirport { Planes = planes }.GetSortedPlanesByMaxLoadCapacity();

            Assert.That(allPlanes, Is.Ordered.By(nameof(Plane.MaxLoadCapacity)));
        }
    }
}

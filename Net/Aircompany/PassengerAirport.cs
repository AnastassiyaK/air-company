using Aircompany.Planes;
using System.Linq;

namespace Aircompany
{
    public class PassengerAirport : Airport<PassengerPlane>
    {
        public PassengerPlane GetPlaneWithMaxPassengersCapacity()
        {
            return _planes.OrderByDescending(p => p.PassengersCapacity).First();
        }
    }
}

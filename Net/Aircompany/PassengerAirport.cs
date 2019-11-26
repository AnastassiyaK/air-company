using Aircompany.Exceptions;
using Aircompany.Planes;
using System.Linq;

namespace Aircompany
{
    public class PassengerAirport : Airport<PassengerPlane>
    {
        public PassengerPlane GetPlaneWithMaxPassengersCapacity()
        {
            return _planes.Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);
        }
    }
}

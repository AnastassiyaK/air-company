using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class MixedAirport : Airport<Plane>
    {
        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes.Where(p => p is PassengerPlane).Cast<PassengerPlane>().ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.Where(p => p is MilitaryPlane).Cast<MilitaryPlane>().ToList();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(p => p.Type == MilitaryType.TRANSPORT).ToList();
        }
    }
}

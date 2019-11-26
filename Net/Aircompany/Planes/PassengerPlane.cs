using Newtonsoft.Json;
using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private static readonly int hashCode = 751774561;

        [JsonProperty("PassengersCapacity")]
        public int PassengersCapacity { get; set; }

        public override bool Equals(object obj)
        {
            var plane = obj as PassengerPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   PassengersCapacity == plane.PassengersCapacity;
        }

        public override int GetHashCode()
        {
            var tempHashCode = hashCode * integer + base.GetHashCode();
            tempHashCode = tempHashCode * integer + PassengersCapacity.GetHashCode();
            return tempHashCode;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", passengersCapacity=" + PassengersCapacity +
                    '}');
        }
    }
}

using Newtonsoft.Json;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
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
            var hashCode = 751774561;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + PassengersCapacity.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", passengersCapacity=" + PassengersCapacity + '}');
        }
    }
}

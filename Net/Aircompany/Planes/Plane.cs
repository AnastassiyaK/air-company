using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        protected const int integer = -1521134295;

        private static readonly int hashCode = -1043886837;

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("MaxSpeed")]
        public int MaxSpeed { get; set; }

        [JsonProperty("MaxFlightDistance")]
        public int MaxFlightDistance { get; set; }

        [JsonProperty("MaxLoadCapacity")]
        public int MaxLoadCapacity { get; set; }

        public override string ToString()
        {
            return "Plane{" +
                "model='" + Model + '\'' +
                ", maxSpeed=" + MaxSpeed +
                ", maxFlightDistance=" + MaxFlightDistance +
                ", maxLoadCapacity=" + MaxLoadCapacity +
                '}';
        }

        public override bool Equals(object obj)
        {
            var plane = obj as Plane;
            return plane != null &&
                   Model == plane.Model &&
                   MaxSpeed == plane.MaxSpeed &&
                   MaxFlightDistance == plane.MaxFlightDistance &&
                   MaxLoadCapacity == plane.MaxLoadCapacity;
        }

        public override int GetHashCode()
        {
            var tempHashCode = hashCode * integer + EqualityComparer<string>.Default.GetHashCode(Model);
            tempHashCode = tempHashCode * integer + MaxSpeed.GetHashCode();
            tempHashCode = tempHashCode * integer + MaxFlightDistance.GetHashCode();
            tempHashCode = tempHashCode * integer + MaxLoadCapacity.GetHashCode();
            return tempHashCode;
        }
    }
}

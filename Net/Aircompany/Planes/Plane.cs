using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Plane{model = '");
            stringBuilder.Append(Model);
            stringBuilder.Append('\'');
            stringBuilder.Append(", maxSpeed=");
            stringBuilder.Append(MaxSpeed);
            stringBuilder.Append(", maxFlightDistance=");
            stringBuilder.Append(MaxFlightDistance);
            stringBuilder.Append(", maxLoadCapacity=");
            stringBuilder.Append(MaxLoadCapacity);
            stringBuilder.Append('}');
            return stringBuilder.ToString();
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
            var hashCode = -1043886837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 + MaxSpeed.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxFlightDistance.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxLoadCapacity.GetHashCode();
            return hashCode;
        }
    }
}

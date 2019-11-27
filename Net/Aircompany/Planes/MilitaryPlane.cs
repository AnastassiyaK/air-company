using Aircompany.Models;
using Newtonsoft.Json;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        [JsonProperty("MilitaryType")]
        public MilitaryType Type { get; set; }

        public bool IsTransport()
        {
            return Type == MilitaryType.Transport;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   Type == plane.Type;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", type=" + Type + '}');
        }
    }
}

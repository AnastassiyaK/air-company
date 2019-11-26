using Aircompany.Exceptions;
using Aircompany.Models;
using Newtonsoft.Json;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private static readonly int hashCode = 1701194404;

        [JsonProperty("MilitaryType")]
        public MilitaryType Type { get; set; }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   Type == plane.Type;
        }

        public override int GetHashCode()
        {
            var tempHashCode = hashCode * integer + base.GetHashCode();
            tempHashCode = tempHashCode * integer + Type.GetHashCode();
            return tempHashCode;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + Type +
                    '}');
        }
    }
}

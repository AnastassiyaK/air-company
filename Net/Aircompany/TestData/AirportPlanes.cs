using Aircompany.Planes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Aircompany.Data
{
    public class AirportPlanes
    {
        static AirportPlanes()
        {
            var planes = JsonConvert.DeserializeObject<AirportPlanes>(GetJSONString());
            Planes.AddRange(PassengersPlanes);
            Planes.AddRange(MilitaryPlanes);
        }

        [JsonProperty("PassengerPlanes")]
        public static List<PassengerPlane> PassengersPlanes { get; set; }

        [JsonProperty("MilitaryPlanes")]
        public static List<MilitaryPlane> MilitaryPlanes { get; set; }

        public static List<Plane> Planes { get; set; } = new List<Plane>();

        public static string GetJSONString()
        {
            return File.ReadAllText($@"{GetExecutingDirectory()}\TestData\Planes.json");
        }

        private static string GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
    }
}

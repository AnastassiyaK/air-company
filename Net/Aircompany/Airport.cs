using Aircompany.Exceptions;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public abstract class Airport<T> where T : Plane
    {
        protected List<T> _planes;

        public List<T> Planes
        {
            get
            {
                return _planes ?? throw new PlanesNoFoundException("Planes were not set.");
            }

            set
            {
                _planes = value;
            }
        }

        public Airport<T> SortByMaxDistance()
        {
            _planes = Planes.OrderBy(w => w.MaxFlightDistance).ToList();
            return this;
        }

        public Airport<T> SortByMaxSpeed()
        {
            _planes = Planes.OrderBy(w => w.MaxSpeed).ToList();
            return this;
        }

        public Airport<T> SortByMaxLoadCapacity()
        {
            _planes = Planes.OrderBy(w => w.MaxLoadCapacity).ToList();
            return this;
        }

        public List<T> GetSortedPlanesByMaxLoadCapacity()
        {
            return SortByMaxLoadCapacity().Planes;
        }

        public override string ToString()
        {
            return string.Concat("Airport{planes = ", string.Join(", ", Planes.Select(x => x.Model)), '}');
        }
    }
}

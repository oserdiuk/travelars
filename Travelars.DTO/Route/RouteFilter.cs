using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelars.DTO.Route
{
    public class RouteFilter
    {
        public int NumberOfTravelers { get; set; }

        public string City { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public RouteOrientation RouteOrientation { get; set; }

        public IList<PlaceType> PlaceTypes { get; set; }
    }
}

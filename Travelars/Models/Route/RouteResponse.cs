using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travelars.DTO.Route;

namespace Travelars.Models.Route
{
    public class RouteResponse
    {
        public IEnumerable<IEnumerable<PlaceVisit>> SchedulePerDay { get; set; }

        public int NumberOfTravelers { get; set; }

        public string City { get; set; }

        public int Distance { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<RouteOrientation> RouteOrientation { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travelars.Models.Route
{
    public class RouteRequest
    {
        public int NumberOfTravelers { get; set; }

        public RouteOrientation RouteOrientation { get; set; }

        public bo Type { get; set; }
    }
}
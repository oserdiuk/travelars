using System;
using System.Collections.Generic;
using Travelars.DTO.GoogleModels;

namespace Travelars.DTO.Route
{
    public class RouteFilter
    {
        public int NumberOfTravelers { get; set; }

        public string City { get; set; }

        public PriceLevel PriceLevel { get; set; }

        public int MaxNumberOfPlacesPerDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<RouteOrientation> RouteOrientation { get; set; }

        public IEnumerable<PlaceType> PlaceTypes { get; set; }
    }
}

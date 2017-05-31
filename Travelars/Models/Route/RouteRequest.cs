using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoogleApiService.Entities.Places.Search.Common.Enums;
using Travelars.DTO.Route;

namespace Travelars.Models.Route
{
    public class RouteRequest
    {
        public int NumberOfTravelers { get; set; }

        public string City { get; set; }

        public int MaxNumberOfPlacesPerDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<RouteOrientation> RouteOrientation { get; set; }

        public IEnumerable<SearchPlaceType> PlaceTypes { get; set; }
    }
}
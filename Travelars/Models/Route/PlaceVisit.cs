using System;
using GoogleApiService.Entities.Places.Search.Common.Enums;

namespace Travelars.Models.Route
{
    public class PlaceVisit
    {
        public DateTime VisitStartTime { get; set; }

        public DateTime VisitEndTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SearchPlaceType SearchPlaceType { get; set; }

        public string ImageUrl { get; set; }
    }
}
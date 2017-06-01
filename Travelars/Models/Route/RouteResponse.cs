using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travelars.DTO.Route;
using Travelars.Models.Route;


namespace Travelars.Models.Route
{
    public class RouteResponse
    {
        public RouteResponse(int numberOfTravelers, 
            int maxNumberOfPlacesPerDate, 
            DateTime startDate, 
            DateTime endDate, 
            IEnumerable<RouteOrientation> routeOrientation,
            IEnumerable<IEnumerable<Route.PlaceVisit>> schedulePerDay)
        {
            Id = Guid.NewGuid();
            NumberOfTravelers = numberOfTravelers;
            MaxNumberOfPlacesPerDate = maxNumberOfPlacesPerDate;
            StartDate = startDate;
            EndDate = endDate;
            RouteOrientation = routeOrientation;
            SchedulePerDay = schedulePerDay;
        }

        public Guid Id { get; set; }

        public IEnumerable<IEnumerable<Travelars.Models.Route.PlaceVisit>> SchedulePerDay { get; set; }

        public int NumberOfTravelers { get; set; }

        public string City { get; set; }

        public int MaxNumberOfPlacesPerDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<RouteOrientation> RouteOrientation { get; set; }
    }
}
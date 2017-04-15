using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelars.DTO.Route
{
    public class RoutePlan
    {
        public Guid Id { get; set; }

        public IEnumerable<DayActivity> SchedulePerDay { get; set; }

        public int NumberOfTravelers { get; set; }

        public string City { get; set; }

        public int Distance { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<RouteOrientation> RouteOrientation { get; set; }
    }
}

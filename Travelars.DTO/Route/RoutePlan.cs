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

        public IList<DayActivity> SchedulePerDay { get; set; } = new List<DayActivity>();

        public int NumberOfTravelers { get; set; }

        public IList<string> Cities { get; set; } = new List<string>();

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public IEnumerable<RouteOrientation> RouteOrientation { get; set; }
    }
}

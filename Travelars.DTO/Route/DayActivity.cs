using System;
using System.Collections.Generic;

namespace Travelars.DTO.Route
{
    public class DayActivity
    {
        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public IList<PlaceVisit> Places { get; set; } = new List<PlaceVisit>();
    }
}
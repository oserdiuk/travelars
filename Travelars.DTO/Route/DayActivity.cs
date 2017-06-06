using System;
using System.Collections.Generic;

namespace Travelars.DTO.Route
{
    public class DayActivity
    {
        public DayActivity(DateTime date)
        {
            Id = Guid.NewGuid();
            Date = date;
            Places = new List<PlaceVisit>();
        }

        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public IList<PlaceVisit> Places { get; set; } 
    }
}
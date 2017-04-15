using System;
using System.Collections.Generic;

namespace Travelars.DTO.Route
{
    public class DayActivity
    {
        public Guid Id { get; set; }

        public IEnumerable<PlaceVisit> Type { get; set; }
    }
}
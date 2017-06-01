using System;
using System.Collections.Generic;

namespace Travelars.Models.Ticket
{
    public class TicketsVariant
    {
        public string Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan Duration { get; set; }
        public Trip Trip { get; set; }
        public List<Car> Cars { get; set; }
    }
}
using System;
using System.Linq;
using System.Web;

namespace Travelars.Models.Ticket
{
    public class TicketsResponse
    {
        public Station DepartureStation { get; set; }
        public Station ArrivalStation { get; set; }
        public TicketsVariant Variants { get; set; }
        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
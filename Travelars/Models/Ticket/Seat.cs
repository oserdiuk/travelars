using System.Collections.Generic;

namespace Travelars.Models.Ticket
{
    public class Seat
    {
        public SeatsType Type { get; set; }
        public List<string> FreeSeats { get; set; }
    }
}
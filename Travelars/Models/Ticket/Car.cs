using System.Collections.Generic;

namespace Travelars.Models.Ticket
{
    public class Car
    {
        public int Number { get; set; }
        public CarType Type { get; set; }
        public List<Seat> Seats { get; set; }
        public decimal Price { get; set; }
    }
}
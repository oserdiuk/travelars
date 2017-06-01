using System;

namespace Travelars.Models.Ticket
{
    public class TicketsRequest
    {
        public string  DepartureStationId { get; set; }

        public string ArrivalStationId { get; set; }

        public TransportType TransportType { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfInfants { get; set; }

        public int NumberOfChilds{ get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public TransportClass Class { get; set; }
    }

    public enum TransportClass
    {
        Econom, 
        Business,
        Lux
    }

    public enum TransportType
    {
        Railway,
        Bus,
        Plane
    }
}
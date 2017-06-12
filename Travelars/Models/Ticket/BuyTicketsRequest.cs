using System;
using System.Collections.Generic;

namespace Travelars.Models.Ticket
{
    public class BuyTicketsRequest
    {
        public string  VatiantId  { get; set; }
        public string  ReturnVatiantId  { get; set; }
        public List<SeatRequest> Seats { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
        public string RouteId { get; set; }
    }

    public class BuyTicketsResponse
    {
        public string LinkForPaying { get; set; }
        public Station DepartureStation { get; set; }
        public Station ArrivalStation { get; set; }
        public TicketsVariant Variants { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public List<SeatRequest> Seats { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
    }

    public class SeatRequest
    {
        public string CarId { get; set; }
        public int PlaceNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }

    }
}
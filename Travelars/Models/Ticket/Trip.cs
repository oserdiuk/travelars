namespace Travelars.Models.Ticket
{
    public class Trip
    {
        public string Id { get; set; }
        public Station DepartureStation { get; set; }
        public Station ArrivalStation { get; set; }
    }
}
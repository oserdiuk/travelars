using System.Collections.Generic;
using Travelars.DTO.GoogleModels;

namespace Travelars.DTO.Route
{
    public class PlaceVisit
    {
        public List<PlaceType> PlaceType { get; set; }

        public string PlaceId { get; set; }

        public string  Address { get; set; }

        public List<string> Phones { get; set; }

        public string Name { get; set; }

        public bool IsOpenNow { get; set; }

        public List<string> OpeningHours { get; set; }

        public List<string> ImageUrls { get; set; }

        public string PriceLevel { get; set; }

        public double Rating { get; set; }

    }
}
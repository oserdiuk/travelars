using System;
using System.Collections.Generic;
using GoogleApiService.Entities.Places.Search.Common.Enums;
using Travelars.DTO.GoogleModels;
using Travelars.DTO.Route;

namespace Travelars.Models.Route
{
    public class PlaceVisit
    {
        public List<string> PlaceType { get; set; }

        public string PlaceId { get; set; }

        public string Address { get; set; }

        public List<string> Phones { get; set; }

        public string Name { get; set; }

        public string Longtitude { get; set; }

        public string Latitude { get; set; }

        public bool IsOpenNow { get; set; }

        public List<string> OpeningHours { get; set; }

        public List<string> ImageUrls { get; set; }

        public PriceLevel PriceLevel { get; set; }

        public double Rating { get; set; }

    }
}
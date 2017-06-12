using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travelars.DTO.Route;

namespace Travelars.Models.Review
{
    public class ReviewRequest
    {
        public string PlaceId { get; set; }
        public int RecommendedTime { get; set; }

        public List<Season> RecommendedSeasons { get; set; }

        public List<PartOfADay> RecommendedPartOfADay { get; set; }

        public double Rate { get; set; }

        public string Review { get; set; }
    }
}
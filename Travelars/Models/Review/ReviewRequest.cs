using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travelars.DTO.Route;

namespace Travelars.Models.Review
{
    public class ReviewRequest
    {
        public TimeSpan RecommendedTime { get; set; }

        public List<Season> RecommendedSeasons { get; set; }

        public PartOfADay RecommendedPartOfADay { get; set; }

        public double Rate { get; set; }

        public string Review { get; set; }
    }
}
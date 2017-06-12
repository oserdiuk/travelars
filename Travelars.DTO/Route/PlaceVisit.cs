using System;
using System.Collections.Generic;

namespace Travelars.DTO.Route
{
    public class PlaceVisit
    {
        public List<PlaceType> PlaceType { get; set; }

        public string PlaceId { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public List<string> Phones { get; set; }

        public string Name { get; set; }

        public bool IsOpenNow { get; set; }

        public List<string> OpeningHours { get; set; }

        public List<string> ImageUrls { get; set; }

        public string PriceLevel { get; set; }

        public double Rating { get; set; }

        public TimeSpan RecomendedTime { get; set; }

        public string RecomendedSeason { get; set; }

        public string RecommendedPartOfADay { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public IList<UserVote> UserVotes { get; set; }

        public void SetVisitTime(DateTime startVisitPlaceDate)
        {
            StartDateTime = startVisitPlaceDate;
            EndDateTime = startVisitPlaceDate.Add(RecomendedTime);
        }
    }

    public class UserVote
    {
        public Guid UserId { get; set; }

        public Guid PlaceId { get; set; }

        public TimeSpan RecomendedTime { get; set; }

        public string RecomendedSeason { get; set; }

        public string RecommendedPartOfADay { get; set; }

        public double UserRate { get; set; }

        public string Review { get; set; }
    }
}
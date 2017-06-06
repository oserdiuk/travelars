using System;

namespace Travelars.Domain.Entities
{
    public class UserVote : Entity
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
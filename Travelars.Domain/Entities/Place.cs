using System;
using System.Collections;
using System.Collections.Generic;

namespace Travelars.Domain.Entities
{
    public class Place : Entity
    {
        public Category Category { get; set; }

        public string PlaceId { get; set; }

        public string  Name { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public double Rate { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }

        public TimeSpan RecomendedTime { get; set; }

        public string RecomendedSeason { get; set; }

        public string  RecommendedPartOfADay{ get; set; }

        public double UserRate { get; set; }

        public virtual ICollection<UserVote> Votes { get; set; }
    }

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

    public enum Category
    {
    }
}

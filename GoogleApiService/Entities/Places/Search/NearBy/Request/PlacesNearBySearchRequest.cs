﻿using System;
using GoogleApiService.Entities.Places.Search.Common;
using GoogleApiService.Entities.Places.Search.NearBy.Request.Enums;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Places.Search.NearBy.Request
{
    /// <summary>
    /// Places NearBySearch Request.
    /// </summary>
    public class PlacesNearBySearchRequest : BasePlacesSearchRequest
    {
        /// <summary>
        /// name — One or more terms to be matched against the names of places, separated with a space character. 
        /// Results will be restricted to those containing the passed name values. Note that a place may have additional names associated with it, beyond its listed name. 
        /// The API will try to match the passed name value against all of these names. As a result, places may be returned in the results whose listed names do not match the search term, 
        /// but whose associated names do.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// keyword — A term to be matched against all content that Google has indexed for this place, including but not limited to name, type, and address, 
        /// as well as customer reviews and other third-party content.
        /// </summary>
        public virtual string Keyword { get; set; }

        /// <summary>
        /// rankby — Specifies the order in which results are listed. Possible values are:
        /// - prominence (default). 
        /// This option sorts results based on their importance. Ranking will favor prominent places within the specified area. 
        /// - Prominence, can be affected by a place's ranking in Google's index, global popularity, and other factors.
        /// - Distance. This option biases search results in ascending order by their distance from the specified location. When distance is specified, one or more of keyword, name, or types is required.
        /// If rankby=distance is specified, then one or more of keyword, name, or types is required.
        /// </summary>
        public virtual Ranking Rankby { get; set; }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "nearbysearch/json";

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.Location == null)
                throw new ArgumentException("Location must not be null");

            if (this.Rankby == Ranking.Distance)
            {
                if (this.Radius.HasValue)
                    throw new ArgumentException("Radius must not have value when RankBy=distance");

                if (string.IsNullOrWhiteSpace(this.Name) && string.IsNullOrWhiteSpace(this.Keyword) && !this.Type.HasValue)
                    throw new ArgumentException("If rankby=distance is specified, then one or more of keyword, name or type is required.");
            }
            else
            {
                if (!this.Radius.HasValue)
                    throw new ArgumentException("Radius must not be null when RankBy is not Distance");

                if (this.Radius > 50000 || this.Radius < 1)
                    throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000.");
            }

            if (!string.IsNullOrWhiteSpace(this.Name))
                parameters.Add("name", this.Name);

            if (!string.IsNullOrWhiteSpace(this.Keyword))
                parameters.Add("keyword", this.Keyword);

            parameters.Add("rankby", this.Rankby.ToString().ToLower());

            return parameters;
        }
    }
}
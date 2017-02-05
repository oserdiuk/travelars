﻿using System;
using GoogleApiService.Entities.Places.Search.Common;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Places.Search.Text.Request
{
    /// <summary>
    /// Places TextSearch Request.
    /// </summary>
    public class PlacesTextSearchRequest : BasePlacesSearchRequest
    {
        /// <summary>
        /// Query — The text string on which to search, for example: "restaurant". 
        /// The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "textsearch/json";

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Query))
                throw new ArgumentException("Query must not be null");

            parameters.Add("query", this.Query);

            return parameters;
        }
    }
}
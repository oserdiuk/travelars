﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Places.Common;
using GoogleApiService.Entities.Places.Common.Enums;
using GoogleApiService.Entities.Places.Search.Common.Enums;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Places.Search.Common
{
    /// <summary>
    /// PlacesBaseSearch Request.
    /// Base abstract class for places search.
    /// </summary>
    public abstract class BasePlacesSearchRequest : BasePlacesRequest, IQueryStringRequest
    {
        /// <summary>
        /// The point around which you wish to retrieve Place information (required). Must be specified as latitude,longitude.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// The distance (in meters) within which to return Place results (required). Note that setting a radius biases results to the indicated area, 
        /// but may not fully restrict results to the specified area. See Location Biasing below.
        /// </summary>
        public virtual double? Radius { get; set; }

        /// <summary>
        /// DEPRECATED.
        /// zagatselected — Add this parameter (just the parameter name, with no associated value) to restrict your search to locations that are Zagat selected businesses. 
        /// This parameter must not include a true or false value. The zagatselected parameter is experimental, and is only available to Google Places API for Work customers.
        /// </summary>
        [Obsolete("May 2, 2017")]
        public virtual bool Zagatselected { get; set; }

        /// <summary>
        /// opennow — Returns only those places that are open for business at the time the query is sent. 
        /// Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.
        /// </summary>
        public virtual bool OpenNow { get; set; }

        /// <summary>
        /// Restricts the results to places matching the specified type. 
        /// Only one type may be specified (if more than one type is provided, all types following the first entry are ignored). 
        /// </summary>
        public virtual SearchPlaceType? Type { get; set; }

        /// <summary>
        /// DEPRECATED.
        /// types — Restricts the results to places matching at least one of the specified types. 
        /// Types should be separated with a pipe symbol (type1|type2|etc). See the list of supported types.
        /// https://developers.google.com/places/supported_types
        /// </summary>
        [Obsolete("February 16, 2017")]
        public virtual IEnumerable<SearchPlaceType> Types { get; set; }

        /// <summary>
        /// minprice and maxprice (optional) — Restricts results to only those places within the specified range. 
        /// Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.
        /// </summary>
        public virtual PriceLevel? Minprice { get; set; }

        /// <summary>
        /// minprice and maxprice (optional) — Restricts results to only those places within the specified range. 
        /// Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.
        /// </summary>
        public virtual PriceLevel? Maxprice { get; set; }

        /// <summary>
        /// The language in which to return results. See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive. If language is not supplied, the Place service will attempt to use the native language of the domain from which the request is sent.
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// pagetoken — Returns the next 20 results from a previously run search. 
        /// Setting a pagetoken parameter will execute a search with the same parameters used previously — all parameters other than pagetoken will be ignored.
        /// </summary>
        public virtual string PageToken { get; set; }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (Location != null)
                parameters.Add("location", Location.ToString());

            if (this.Radius.HasValue)
                parameters.Add("radius", this.Radius.Value.ToString(CultureInfo.InvariantCulture));

            if (this.Types != null && this.Types.Any())
                parameters.Add("types", string.Join("|", this.Types.Select(x => x.ToString().ToLower())));

            if (!string.IsNullOrEmpty(Language))
                parameters.Add("language", Language);

            if (!string.IsNullOrWhiteSpace(this.PageToken))
                parameters.Add("pagetoken", this.PageToken);

            if (this.Type.HasValue)
                parameters.Add("type", this.Type.Value.ToString().ToLower());

            if (this.Minprice.HasValue)
                parameters.Add("minprice", this.Minprice.Value.ToString().ToLower());

            if (this.Maxprice.HasValue)
                parameters.Add("maxprice", this.Maxprice.Value.ToString().ToLower());

            if (this.OpenNow)
                parameters.Add("opennow", "");

            if (this.Zagatselected)
                parameters.Add("zagatselected", "");

            return parameters;
        }
    }
}
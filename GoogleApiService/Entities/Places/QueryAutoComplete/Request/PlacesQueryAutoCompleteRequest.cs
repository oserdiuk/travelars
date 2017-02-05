﻿using System;
using System.Globalization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Places.Common;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Places.QueryAutoComplete.Request
{
	/// <summary>
    /// Places QueryAutoComplete Request.
	/// </summary>
    public class PlacesQueryAutoCompleteRequest : BasePlacesRequest, IQueryStringRequest
	{
        /// <summary>
        /// The text string on which to search. The Place service will return candidate matches based on this string and order results based on their perceived relevance.
        /// </summary>
        public virtual string Input { get; set; } 

        /// <summary>
        /// The character position in the input term at which the service uses text for predictions. For example, if the input is 'Googl' and the completion point is 3, the service will match on 'Goo'. The offset should generally be set to the position of the text caret. If no offset is supplied, the service will use the entire term.        
        /// </summary>
        public virtual string Offset { get; set; }

        /// <summary>
        /// The point around which you wish to retrieve Place information. Must be specified as latitude,longitude.
		/// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// The distance (in meters) within which to return Place results. Note that setting a radius biases results to the indicated area, but may not fully restrict results to the specified area. See Location Biasing below.
		/// </summary>
        public virtual double? Radius { get; set; }

		/// <summary>
        /// The language in which to return results. See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive. If language is not supplied, the Place service will attempt to use the native language of the domain from which the request is sent.
		/// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "queryautocomplete/json";

	    /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
		{
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrEmpty(this.Input))
                throw new ArgumentException("Input must not null or empty"); 
            
            if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
				throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000.");

            parameters.Add("input", this.Input);

            if (!string.IsNullOrEmpty(this.Offset))
                parameters.Add("offset", this.Offset);

            if (this.Location != null)
                parameters.Add("location", this.Location.ToString());
	
            if (this.Radius.HasValue)
				parameters.Add("radius", this.Radius.Value.ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(this.Language))
                parameters.Add("language", this.Language);

            return parameters;
		}
	}
}

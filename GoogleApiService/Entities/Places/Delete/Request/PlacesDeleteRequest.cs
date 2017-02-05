﻿using System;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Places.Common;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Places.Delete.Request
{
    /// <summary>
    /// Places Delete Request.
    /// </summary>
    [DataContract]
    public class PlacesDeleteRequest : BasePlacesRequest, IJsonRequest
    {
        /// <summary>
        /// A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeid field of a Place request. 
        /// For more information about place IDs, see the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "delete/json";

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.PlaceId))
                throw new ArgumentException("PlaceId must be provided.");

            return parameters;
        }
    }
}
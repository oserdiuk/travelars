﻿using System;
using GoogleApiService.Entities.Common;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places requests.
    /// </summary>
    public abstract class BasePlacesRequest : SignableRequest
    {
        private const string BASE_URL = "maps.googleapis.com/maps/api/place/";

        /// <summary>
        /// True to use use the https protocol; false to use http. The default is false.
        /// </summary>
        public override bool IsSsl
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotSupportedException("This operation is not supported, PlacesRequest must use SSL");
            }
        }

        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => BasePlacesRequest.BASE_URL;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("ApiKey must be provided");

            parameters.Add("key", this.Key);

            return parameters;
        }
    }
}
﻿using System;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Maps.Common;
using GoogleApiService.Extensions;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Maps.TimeZone.Request
{
    /// <summary>
    /// TimeZone Request.
    /// </summary>
    public class TimeZoneRequest : BaseMapsRequest, IQueryStringRequest
    {
        private const string BASE_URL = "maps.googleapis.com/maps/api/timezone/json";

        /// <summary>
        /// A comma-separated lat,lng tuple (eg. location=-33.86,151.20), representing the location to look up
        /// </summary>
        public virtual Location Location { get; set; } 
        
        /// <summary>
        /// Timestamp specifies the desired time as seconds since midnight, January 1, 1970 UTC. The Time Zone API uses the timestamp to determine whether or not Daylight Savings should be applied. Times before 1970 can be expressed as negative values.
        /// </summary>
        public virtual DateTime TimeStamp { get; set; }
        
        /// <summary>
        /// The language in which to return results. See the list of supported domain languages. Note that we often update supported languages so this list may not be exhaustive. Defaults to en.
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// Always true. Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, TimeZoneRequest must use SSL"); }
        }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => TimeZoneRequest.BASE_URL;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if (this.Location == null)
                throw new ArgumentException("Location is required");

            if (this.TimeStamp == null)
                throw new ArgumentException("TimeStamp is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("location", this.Location.LocationString);
            parameters.Add("timestamp", this.TimeStamp.DateTimeToUnixTimestamp().ToString());

            if (!string.IsNullOrWhiteSpace(this.Language)) 
                parameters.Add("language", this.Language);

            return parameters;
        }
    }
}
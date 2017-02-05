﻿using System;
using System.Globalization;
using System.Linq;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Maps.Common;
using GoogleApiService.Entities.Maps.Common.Enums;
using GoogleApiService.Extensions;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Maps.Directions.Request
{
    /// <summary>
    /// Directions Request.
    /// </summary>
    public class DirectionsRequest : BaseMapsRequest, IQueryStringRequest
	{
		/// <summary>
		/// origin (required) — The address or textual latitude/longitude value from which you wish to calculate directions. *
		/// </summary>
        public virtual string Origin { get; set; }

		/// <summary>
		/// destination (required) — The address or textual latitude/longitude value from which you wish to calculate directions.*
		/// </summary>
        public virtual string Destination { get; set; }

        /// <summary>
        /// Directions results contain text within distance fields to indicate the distance of the calculated route. The unit system to use can be specified:
        /// Units=metric (default) returns distances in kilometers and meters.
        /// Units=imperial returns distances in miles and feet.
        /// * Note: this unit system setting only affects the text displayed within distance fields. The distance fields also contain values which are always expressed in meters
        /// </summary>
        public Units Units { get; set; }

        /// <summary>
        /// avoid (optional) indicates that the calculated route(s) should avoid the indicated features. Currently, this parameter supports the following two arguments:
        /// tolls indicates that the calculated route should avoid toll roads/bridges.
        /// highways indicates that the calculated route should avoid highways.
        /// (For more information see Route Restrictions below.)
        /// </summary>
        public AvoidWay Avoid { get; set; }

        /// <summary>
        /// (optional, defaults to driving) — specifies what mode of transport to use when calculating directions. Valid values are specified in Travel Modes.
        /// </summary>
        public TravelMode TravelMode { get; set; }

        /// <summary>
        /// Specifies one or more preferred modes of transit. 
        /// This parameter may only be specified for requests where the mode is transit. 
        /// The parameter supports the following arguments <see cref="Common.Enums.TransitMode"/>
        /// </summary>
        public TransitMode TransitMode { get; set; }

        /// <summary>
        /// Specifies preferences for transit requests. 
        /// Using this parameter, you can bias the options returned, rather than accepting the default best route chosen by the API. 
        /// This parameter may only be specified for requests where the mode is transit. 
        /// The parameter supports the following arguments: <see cref="Common.Enums.TransitRoutingPreference"/>
        /// </summary>
        public TransitRoutingPreference TransitRoutingPreference { get; set; }

		/// <summary>
		/// The time of departure.
		/// Required when TravelMode = Transit
		/// </summary>
        public virtual DateTime DepartureTime { get; set; }

		/// <summary>
		/// The time of arrival.
		/// Required when TravelMode = Transit
		/// </summary>
        public virtual DateTime ArrivalTime { get; set; }

		/// <summary>
		/// waypoints (optional) specifies an array of waypoints. Waypoints alter a route by routing it through the specified location(s). 
		/// A waypoint is specified as either a latitude/longitude coordinate or as an address which will be geocoded. (For more information on waypoints, see Using Waypoints in Routes below.)
        /// If you'd like to influence the route using waypoints without adding a stopover, prefix the waypoint with 'via:' (deprecated On Aug 20, 2017)
        /// Waypoints prefixed with via: will not add an entry to the legs array, but will instead route the journey through the provided waypoint.
        /// The via: prefix is most effective when creating routes in response to the user dragging the waypoints on the map. Doing so allows the user to see how the final route may look in real-time and helps ensure that waypoints are placed in locations that are accessible to the Google Maps Directions API.
        /// Caution: Using the via: prefix to avoid stopovers results in directions that are very strict in their interpretation of the waypoint. This may result in severe detours on the route or ZERO_RESULTS in the response status code if the Google Maps Directions API is unable to create directions through that point.
		/// </summary>
        public virtual string[] Waypoints { get; set; }

		/// <summary>
		/// optimize the provided route by rearranging the waypoints in a more efficient order. (This optimization is an application of the Travelling Salesman Problem.)
		/// http://en.wikipedia.org/wiki/Travelling_salesman_problem
		/// </summary>
        public virtual bool OptimizeWaypoints { get; set; }

		/// <summary>
		/// alternatives (optional), if set to true, specifies that the Directions service may provide more than one route alternative in the response. Note that providing route alternatives may increase the response time from the server.
		/// </summary>
        public virtual bool Alternatives { get; set; }

        /// <summary>
        /// Specifies the region code, specified as a ccTLD ("top-level domain") two-character value. (For more information see Region Biasing below.)
        /// </summary>
        public virtual string Region { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results. See the supported list of domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the Directions service will attempt to use the native language of the browser wherever possible. 
        /// You may also explicitly bias the results by using localized domains of http://map.google.com. 
        /// See Region Biasing for more information.
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DirectionsRequest()
        {
            this.Units = Units.Metric;
            this.Avoid = AvoidWay.Nothing;
            this.TravelMode = TravelMode.Driving;
            this.TransitMode = TransitMode.Bus | TransitMode.Train | TransitMode.Subway | TransitMode.Tram;
            this.TransitRoutingPreference = TransitRoutingPreference.Nothing;
        }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "directions/json";

	    /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
		{
			if (string.IsNullOrWhiteSpace(this.Origin))
				throw new ArgumentException("Must specify an Origin");
            
            if (string.IsNullOrWhiteSpace(this.Destination))
				throw new ArgumentException("Must specify a Destination");
            
            if (!Enum.IsDefined(typeof(AvoidWay), this.Avoid))
				throw new ArgumentException("Invalid enumeration value for 'Avoid'");
            
            if (!Enum.IsDefined(typeof(TravelMode), this.TravelMode))
				throw new ArgumentException("Invalid enumeration value for 'TravelMode'");

            if (this.TravelMode == TravelMode.Transit && this.DepartureTime == default(DateTime) && this.ArrivalTime == default(DateTime))
				throw new ArgumentException("You must set either DepatureTime or ArrivalTime when TravelMode = Transit");

			var parameters = base.GetQueryStringParameters();
            
            parameters.Add("origin", this.Origin);
            parameters.Add("destination", this.Destination);
            parameters.Add("units", this.Units.ToString().ToLower());
            parameters.Add("mode", this.TransitMode.ToString().ToLower());

            if (this.Region != null)
                parameters.Add("region", this.Region);

            if (this.Alternatives)
				parameters.Add("alternatives", "true");

		    if (this.Avoid != AvoidWay.Nothing)
                parameters.Add("avoid", this.Avoid.ToEnumString('|'));

            if (!string.IsNullOrWhiteSpace(this.Language))
                parameters.Add("language", this.Language);

            if (this.Waypoints != null && this.Waypoints.Any())
                parameters.Add("waypoints", string.Join("|", this.OptimizeWaypoints ? new[] { "optimize:true" }.Concat(Waypoints) : this.Waypoints));

            if (this.TravelMode == TravelMode.Transit)
            {
                parameters.Add("transit_mode", this.TransitMode.ToEnumString('|'));

                if (this.TransitRoutingPreference != TransitRoutingPreference.Nothing)
                    parameters.Add("transit_routing_preference", this.TransitRoutingPreference.ToEnumString('|'));
                
                if (this.ArrivalTime != default(DateTime))
                    parameters.Add("arrival_time", this.ArrivalTime.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

                if (this.DepartureTime != default(DateTime))
                    parameters.Add("departure_time", this.DepartureTime.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));
            }

			return parameters;
		}
	}
}
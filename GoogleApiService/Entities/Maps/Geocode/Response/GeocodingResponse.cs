using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;

namespace GoogleApiService.Entities.Maps.Geocode.Response
{
    /// <summary>
    /// Geocoding Response.
    /// </summary>
	[DataContract]
	public class GeocodingResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// Results array.
        /// </summary>
		[DataMember(Name = "results")]
        public virtual IEnumerable<GeocodeResult> Results { get; set; }
	}
}
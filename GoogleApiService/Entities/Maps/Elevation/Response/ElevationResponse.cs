using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;

namespace GoogleApiService.Entities.Maps.Elevation.Response
{
    /// <summary>
    /// Elevation Response.
    /// </summary>
	[DataContract]
	public class ElevationResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// Results.
        /// </summary>
		[DataMember(Name = "results")]
        public virtual IEnumerable<ElevationResult> Results { get; set; }
	}
}

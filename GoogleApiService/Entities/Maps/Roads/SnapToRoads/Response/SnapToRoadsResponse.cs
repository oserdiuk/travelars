using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Maps.Roads.Common;

namespace GoogleApiService.Entities.Maps.Roads.SnapToRoads.Response
{
    /// <summary>
    /// SnapToRoads Response.
    /// </summary>
	[DataContract]
	public class SnapToRoadsResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// An array of snapped points
        /// </summary>
		[DataMember(Name = "snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }
	}
}
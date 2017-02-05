using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Maps.Roads.Common;

namespace GoogleApiService.Entities.Maps.Roads.SpeedLimits.Response
{
    /// <summary>
    /// SpeedLimits Response.
    /// </summary>
	[DataContract]
    public class SpeedLimitsResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// An array of snapped points
        /// </summary>
        [DataMember(Name = "snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }

        /// <summary>
        /// SpeedLimits — An array of road metadata. Each element consists of the following fields:
        /// </summary>
        [DataMember(Name = "speedLimits")]
        public virtual IEnumerable<SpeedLimit> SpeedLimits { get; set; }
    }
}
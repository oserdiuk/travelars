using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;

namespace GoogleApiService.Entities.Places.Common
{
    /// <summary>
    /// Geometry
    /// </summary>
    [DataContract]
    public class Geometry
    {
        /// <summary>
        /// location contains the geocoded latitude,longitude value for this place.
        /// </summary>
        [DataMember(Name = "location")]
        public virtual Location Location { get; set; }
    }
}
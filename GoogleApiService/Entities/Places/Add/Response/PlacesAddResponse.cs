using System.Runtime.Serialization;
using GoogleApiService.Entities.Places.Common;
using GoogleApiService.Entities.Places.Common.Enums;

namespace GoogleApiService.Entities.Places.Add.Response
{
    /// <summary>
    /// Places Add Response.
    /// </summary>
    [DataContract]
    public class PlacesAddResponse : BasePlacesResponse
    {
        /// <summary>
        /// A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeid field of a Place Details request. 
        /// For more information about place IDs, see the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Indicates the scope of the place_id. 
        /// </summary>
        [DataMember(Name = "scope")]
        public virtual Scope Scope { get; set; }
    }
}
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Places.Search.Common;

namespace GoogleApiService.Entities.Places.Search.Text.Response
{
    /// <summary>
    /// Places TextSearch Response.
    /// </summary>
    [DataContract]
    public class PlacesTextSearchResponse : BasePlacesSearchResponse
    {
        /// <summary>
        /// Results
        /// </summary>
        [DataMember(Name = "results")]
        public virtual IEnumerable<TextResult> Results { get; set; }
    }
}
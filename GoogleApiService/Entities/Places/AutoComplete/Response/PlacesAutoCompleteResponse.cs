using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Places.Common;

namespace GoogleApiService.Entities.Places.AutoComplete.Response
{
    /// <summary>
    /// When the Places service returns JSON results from a search, it places them within a predictions array.
    /// </summary>
    [DataContract]
    public class PlacesAutoCompleteResponse : BasePlacesResponse
	{
		/// <summary>
        /// Contains an array of predictions, with information about the prediction.
		/// </summary>
		[DataMember(Name = "predictions")]
        public virtual IEnumerable<Prediction> Predictions { get; set; }
	}
}

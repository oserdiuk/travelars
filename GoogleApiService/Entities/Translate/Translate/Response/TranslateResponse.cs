using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;

namespace GoogleApiService.Entities.Translate.Translate.Response
{
    /// <summary>
    /// Translate Response.
    /// </summary>
    [DataContract]
    public class TranslateResponse : BaseResponse, IResponseFor
    {        
        /// <summary>
        /// Data container returned by google translate.
        /// </summary>
        [DataMember(Name = "data")]
        public virtual Data Data { get; set; }
    }
}
 
 


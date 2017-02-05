using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;

namespace GoogleApiService.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places responses.
    /// </summary>
    [DataContract]
    public abstract class BasePlacesResponse : BaseResponse, IResponseFor
    {
        
    }
}
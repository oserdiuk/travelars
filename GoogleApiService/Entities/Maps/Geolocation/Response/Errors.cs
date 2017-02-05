﻿using System.Runtime.Serialization;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;

namespace GoogleApiService.Entities.Maps.Geolocation.Response
{
    /// <summary>
    /// Errors.
    /// </summary>
    [DataContract]
    public class Errors : BaseResponse, IResponseFor
    {
        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [DataMember(Name = "domain")]
        public virtual string Domain { get; set; }

        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [DataMember(Name = "reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [DataMember(Name = "message")]
        public virtual string Message { get; set; }
    }
}
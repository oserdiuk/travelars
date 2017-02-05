﻿using System;
using System.Runtime.Serialization;
using GoogleApiService.Extensions;

namespace GoogleApiService.Entities.Common
{
    /// <summary>
    /// MapsBase Response.
    /// Base abstract class for Google responses.
    /// </summary>
    [DataContract]
    public abstract class BaseResponse
    {
        /// <summary>
        /// "status" contains metadata on the request.
        /// </summary>
        public virtual Status Status { get; set; }
     
        /// <summary>
        /// When the status code is other than OK, there may be an additional error_message field within the Directions response object. 
        /// This field contains more detailed information about the reasons behind the given status code.
        /// Note: This field is not guaranteed to be always present, and its content is subject to change.
        /// </summary>
        public virtual string ErrorMessage { get; set; }

        [DataMember(Name = "status")]
        internal virtual string StatusStr
        {
            get
            {
                return this.Status.ToEnumString();
            }
            set
            {
                this.Status = value.ToEnum<Status>();
            }
        }

        [DataMember(Name = "error_message")]
        internal virtual string ErrorMsg
        {
            get
            {
                return this.Status.ToString();
            }
            set
            {
                this.Status = (Status)Enum.Parse(typeof(Status), value);
            }
        }
    }
}
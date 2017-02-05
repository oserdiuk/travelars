﻿using System;
using GoogleApiService.Entities.Common;

namespace GoogleApiService.Entities.Maps.Common
{
    /// <summary>
    /// Base abstract class for Maps requests.
    /// </summary>
    public abstract class BaseMapsRequest : SignableRequest
    {
        private const string BASE_URL = "maps.google.com/maps/api/";

        /// <summary>
        /// Always true. Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotSupportedException("This operation is not supported, Request must use SSL");
            }
        }

        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => BaseMapsRequest.BASE_URL;
    }
}

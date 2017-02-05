﻿using System;

namespace GoogleApiService.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Transit Routing Preference.
    /// </summary>
    [Flags]
    public enum TransitRoutingPreference 
    {
        /// <summary>
        /// No TransitRoutingPreference.
        /// </summary>
        Nothing = 0x0,
        /// <summary>
        /// Indicates that the calculated route should prefer limited amounts of walking.
        /// </summary>
        LessWalking = 0x1,
        /// <summary>
        /// Indicates that the calculated route should prefer a limited number of transfers.
        /// </summary>
        FewerTransfers = 0x2
    }
}
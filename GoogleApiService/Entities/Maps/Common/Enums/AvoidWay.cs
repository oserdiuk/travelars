﻿using System;

namespace GoogleApiService.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Avoid Way restrictions.
    /// </summary>
	[Flags]
	public enum AvoidWay
	{
        /// <summary>
        /// Nothing
        /// </summary>
		Nothing = 0x0,
		/// <summary>
		/// Avoid Tolls
		/// </summary>
        Tolls = 0x1,
        /// <summary>
        /// Avoid highways
        /// </summary>
        Highways = 0x2,
    	/// <summary>
    	/// Avoid Indoor
    	/// </summary>
        Indoor = 0x3
}
}

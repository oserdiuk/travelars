﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Maps.Common;
using GoogleApiService.Entities.Maps.Geolocation.Request.Enums;

namespace GoogleApiService.Entities.Maps.Geolocation.Request
{
    /// <summary>
    /// Geolocation Request.
    /// </summary>
    [DataContract]
    public class GeolocationRequest : BaseMapsRequest, IJsonRequest
	{
        private const string BASE_URL = "www.googleapis.com/geolocation/v1/geolocate";

        /// <summary>
        /// The carrier name.
        /// </summary>
        [DataMember(Name = "carrier")]
        public virtual string Carrier { get; set; }

        /// <summary>
        /// The mobile country code (MCC) for the device's home network.
		/// </summary>
        [DataMember(Name = "hmeMobileCountryCode")]
        public virtual string HomeMobileCountryCode { get; set; } 
		
        /// <summary>
        /// The mobile network code (MNC) for the device's home network.
		/// </summary>
        [DataMember(Name = "homeMobileNetworkCode")]
        public virtual string HomeMobileNetworkCode { get; set; }
        
        /// <summary>
        /// The mobile radio type. Supported values are lte, gsm, cdma, and wcdma. While this field is optional, it should be included if a value is available, for more accurate results.
        /// </summary>
        [DataMember(Name = "radioType")]
        public virtual RadioType? RadioType { get; set; }
        
        /// <summary>
        /// Specifies whether to fall back to IP geolocation if wifi and cell tower signals are not available. 
        /// Note that the IP address in the request header may not be the IP of the device. Defaults to true. Set considerIp to false to disable fall back.
        /// </summary>
        [DataMember(Name = "considerIp")]
        public virtual bool ConsiderIp { get; set; }
        
        /// <summary>
        /// An array of cell tower objects. See <see cref="CellTower"/>.
        /// </summary>
        [DataMember(Name = "cellTowers")]
        public virtual IEnumerable<CellTower> CellTowers { get; set; }
        
        /// <summary>
        /// An array of WiFi access point objects. See  <see cref="WifiAccessPoint"/>.
        /// </summary>
        [DataMember(Name = "wifiAccessPoints")]
        public virtual IEnumerable<WifiAccessPoint> WifiAccessPoints { get; set; }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => GeolocationRequest.BASE_URL;
	}
}

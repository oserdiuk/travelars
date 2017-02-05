using System.Linq;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Maps.Geocode.Request;
using GoogleApiService.Entities.Places.Details.Request;
using GoogleApiService.Entities.Places.Search.Radar.Request;
using Travelars.DTO.GoogleModels;
using IApplicationSettingsProvider = Travelars.Infrastructure.Interfaces.IApplicationSettingsProvider;

namespace GoogleApiService
{
    public class GoogleApiProvider
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IApplicationSettingsProvider _appSettingsProvider;

        public GoogleApiProvider(
            IHttpRequestService httpRequestService,
            IApplicationSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
            _httpRequestService = new HttpRequestService();
        }

        public void SearchPlace(SearchPlaceRequest model)
        {
            var key = "AIzaSyALEYF3F-GGdvXIUqdIMk8BiLm1KqidD1s";
            var d = GooglePlaces.RadarSearch.Query(new PlacesRadarSearchRequest
            {
                Key = key,
                Location = GetLocation(model.Address),
                Radius = 1000, 
                Keyword = model.Keyword
            });
            var place = GooglePlaces.Details.Query(new PlacesDetailsRequest
            {
                Key = key,
                PlaceId = d.Results.FirstOrDefault().PlaceId
            });
        }

        //public string GetLocation(string address)
        //{
        //    var coder = new GoogleMapsGeocoding.Geocoder("AIzaSyALEYF3F-GGdvXIUqdIMk8BiLm1KqidD1s");//_appSettingsProvider.GooglePlacesApiKey);
        //    var geocode = coder.Geocode(address);
        //    var location = geocode.Results[0].Geometry.Location;
        //    return $"{location.Lat},{location.Lng}";
        //}

        public Location GetLocation(string address)
        {

            var coder = GoogleMaps.Geocode.Query(new GeocodingRequest()
            {
                Key = "AIzaSyALEYF3F-GGdvXIUqdIMk8BiLm1KqidD1s",
                Address = address
            });//_appSettingsProvider.GooglePlacesApiKey);
            return coder.Results.FirstOrDefault().Geometry.Location;
        }

        private string AddParameter(string key, string value)
        {
            return !string.IsNullOrEmpty(value) ? $"&{key}={value}" : string.Empty;
        }
    }
}

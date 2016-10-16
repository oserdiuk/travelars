using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Travelars.DTO;

namespace GoogleApiService
{
    public class GoogleApiProvider
    {
        private const string SearchPlaceUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
        private const string GooglePlacesKeySettings = "GooglePlacesApiKey";
        private readonly string _apiKeyPlaces;
        private readonly IHttpRequestService _httpRequestService;

        public GoogleApiProvider(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
            _apiKeyPlaces = ConfigurationManager.AppSettings.Get(GooglePlacesKeySettings);
        }

        public void SearchPlace(SearchPlaceDTO model)
        {
            string query = string.Empty;
            using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]{
    new KeyValuePair<string, string>("key", _apiKeyPlaces),
    new KeyValuePair<string, string>("location", GetLocation(model.Address)),
    new KeyValuePair<string, string>("types", model.Radius),
    new KeyValuePair<string, string>("keyword", model.Radius),
    new KeyValuePair<string, string>("language", model.Radius),
    new KeyValuePair<string, string>("minprice", model.Radius),
    new KeyValuePair<string, string>("maxprice", model.Radius),
    new KeyValuePair<string, string>("name", model.Radius),
    new KeyValuePair<string, string>("rankby", model.RankBy),
    new KeyValuePair<string, string>("types", model.Radius),
    new KeyValuePair<string, string>("opennow", model.Radius),
    new KeyValuePair<string, string>("opennow", model.Radius),
    new KeyValuePair<string, string>("opennow", model.Radius),
    new KeyValuePair<string, string>("opennow", model.Radius),
    new KeyValuePair<string, string>("opennow", model.Radius),
}))
            {
                query = content.ReadAsStringAsync().Result;
            }
            string url = builder.ToString();
            var requestParams =
            var response = _httpRequestService.MakeRequest(SearchPlaceUrl, query);
            // Parse the response body. Blocking!
            var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
            foreach (var d in dataObjects)
            {
                Console.WriteLine("{0}", d.Name);
            }
        }

        public string GetLocation(string address)
        {
            GoogleMapsGeocoding.Geocoder coder = new GoogleMapsGeocoding.Geocoder(_apiKeyPlaces);
            var geocode = coder.Geocode(address);
            return geocode.Results.ToString();
        }
    }
}

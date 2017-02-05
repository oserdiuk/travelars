using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GoogleApiService
{
    public class HttpRequestService : IHttpRequestService
    {
        public HttpContent MakeRequest(string url, string urlParameters)
        {
            HttpClient client = new HttpClient();
            url = "https://maps.googleapis.com/maps/api/place/nearbysearch/";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            
            return response.Content;
        }
    }
}

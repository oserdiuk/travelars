using System.Net.Http;

namespace GoogleApiService
{
    public interface IHttpRequestService
    {
        HttpContent MakeRequest(string url, string urlParameters);
    }
}

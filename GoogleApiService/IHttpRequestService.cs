using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApiService
{
    public interface IHttpRequestService
    {
        HttpContent MakeRequest(string url, string urlParameters);
    }
}

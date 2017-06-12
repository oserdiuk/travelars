using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travelars.DTO.GoogleModels;
using Travelars.DTO.Route;
using PlaceVisit = Travelars.Models.Route.PlaceVisit;

namespace Travelars.ApiControllers
{
    [Authorize]
    [RoutePrefix("api/place")]
    public class PlaceController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetRoute([FromUri] string key)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new PlaceVisit
            {
                PlaceType = new List<string> { PlaceType.Park.ToString(), PlaceType.Establishment.ToString() },
                PlaceId = "566722132a9c5db7d22337517dc619dc5989fb89",
                Address = "Kutova Street, 16, Kharkiv",
                Name = "Sad imeni T.G.ShEVChENKO",
                Phones = null,
                IsOpenNow = true,
                OpeningHours = null,
                Rating = 4,
                PriceLevel = PriceLevel.Free,
                ImageUrls = new List<string> { "https://lh5.ggpht.com/-SJMZxfmezRQ/WQg1sv1ABqI/AAAAAAAA7i4/UnpHqHXf_hcNofufkFNhQnkQ6C01htvKwCLIB/s240/photo" }
            });
        }
    }
}

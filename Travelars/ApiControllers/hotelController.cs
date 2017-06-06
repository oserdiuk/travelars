using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Travelars.ApiControllers
{
    public class TicketController : ApiController
    {

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetHotels([FromUri] Guid routeId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage BookHotel([FromUri] Guid routeId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

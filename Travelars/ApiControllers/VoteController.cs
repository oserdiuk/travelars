﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travelars.Models.Review;

namespace Travelars.ApiControllers
{
    [Route("api/vote")]
    public class VoteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SendReview(ReviewRequest model)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

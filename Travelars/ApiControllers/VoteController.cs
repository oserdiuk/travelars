using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travelars.Models.Review;

namespace Travelars.ApiControllers
{
    [Authorize]
    [Route("api/vote")]
    public class VoteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SendReview(ReviewRequest model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Thank you for your review! It's very valuable for us!");
        }
    }
}

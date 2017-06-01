using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Travelars.DTO.GoogleModels;
using Travelars.DTO.Route;
using Travelars.Models.Route;
using Travelars.Services.Abstract;
using PlaceVisit = Travelars.Models.Route.PlaceVisit;

namespace Travelars.ApiControllers
{
    [Route("api/route")]
    public class RouteController : ApiController
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        public RouteController()
        {

        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetRoute([FromUri] Guid routeId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //      {
        //"numberOfTravelers": 2,
        //"city": "Kharkiv",
        //"priceLevel": "Inexpensive",
        //"maxNumberOfPlacesPerDate": 4,
        //"startDate": "2017-08-31",
        //"endDate": "2017-09-2",
        //"routeOrientation": [ "Couple" ],
        //"placeTypes": [ "Park", "Cafe" ]
        //  }
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] RouteRequest requestModel)
        {
            //var request = _mapper.Map<RouteFilter>(requestModel);
            //var route = _routeService.GenerateRoute(request);
            //var model = _mapper.Map<RouteResponse>(route);
            List<IEnumerable<PlaceVisit>> routeSchedule = new List<IEnumerable<PlaceVisit>>();
            var days = requestModel.StartDate.Date.Subtract(requestModel.EndDate.Date).Days;
            var firstDay = new List<PlaceVisit>();
            firstDay.Add(new PlaceVisit
            {
                PlaceType = new List<string> { PlaceType.Cafe.ToString(), PlaceType.Establishment.ToString(), PlaceType.Food.ToString() },
                PlaceId = "86ab955c6a2d528237bc28933bea3d8d4895c472",
                Address = "Konstytutsii Square, 2/2, Kharkiv",
                Phones = new List<string> { "+380 63 403 2515" },
                Name = "Gorodskoye kafe 1654",
                IsOpenNow = false,
                OpeningHours = new List<string>
                {
                     "Monday: 8:00 AM - 11:00 PM",
                     "Tuesday: 8:00 AM - 11:00 PM",
                     "Wednesday: 8:00 AM - 11:00 PM",
                     "Thursday: 8:00 AM - 11:00 PM",
                     "Friday: 8:00 AM - 11:00 PM",
                     "Saturday: 8:00 AM - 11:00 PM",
                     "Sunday: 10:00 AM - 11:00 PM"
                },
                Rating = 4.6,
                PriceLevel = PriceLevel.Free,
                ImageUrls = new List<string> { "https://lh5.ggpht.com/-SJMZxfmezRQ/WQg1sv1ABqI/AAAAAAAA7i4/UnpHqHXf_hcNofufkFNhQnkQ6C01htvKwCLIB/s240/photo"}
            });
            firstDay.Add(new PlaceVisit
            {
                PlaceType = new List<string> { PlaceType.Park.ToString(), PlaceType.Establishment.ToString() },
                PlaceId = "566722132a9c5db7d22337517dc619dc5989fb89",
                Address = "Kutova Street, 16, Kharkiv",
                Phones = null,
                IsOpenNow = true,
                OpeningHours = null,
                Rating = 4,
                PriceLevel = PriceLevel.Free,
                ImageUrls = new List<string> { "https://lh5.ggpht.com/-SJMZxfmezRQ/WQg1sv1ABqI/AAAAAAAA7i4/UnpHqHXf_hcNofufkFNhQnkQ6C01htvKwCLIB/s240/photo" }
            });
            routeSchedule.Add(firstDay);
            var route = new RouteResponse(requestModel.NumberOfTravelers,
                requestModel.MaxNumberOfPlacesPerDate,
                requestModel.StartDate,
                requestModel.EndDate,
                requestModel.RouteOrientation,
                routeSchedule);
            return Request.CreateResponse(HttpStatusCode.OK, route);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage EditRoute([FromBody] RouteResponse route)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage DeleteRoute([FromUri] Guid routeId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

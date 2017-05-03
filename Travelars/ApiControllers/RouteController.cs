using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Travelars.DTO.Route;
using Travelars.Models.Route;
using Travelars.Services.Abstract;

namespace Travelars.ApiControllers
{
    public class RouteController : ApiController
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] RouteRequest requestModel)
        {
            var request = _mapper.Map<RouteFilter>(requestModel);
            var route = _routeService.GenerateRoute(request);
            var model = _mapper.Map<RouteResponse>(route);
            return Request.CreateResponse(HttpStatusCode.OK, route);
        }
    }
}

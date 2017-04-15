using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
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
            var routes = _routeService.GenerateRoutes(requestModel);
            var model = _mapper.Map<IEnumerable<RouteResponse>>(routes);
            return Request.CreateResponse(HttpStatusCode.OK, routes);
        }
    }
}

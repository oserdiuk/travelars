using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelars.DTO.Route;

namespace Travelars.Services.Abstract
{
    public interface IRouteService
    {
        RoutePlan GenerateRoute(RouteFilter requestModel);
    }
}

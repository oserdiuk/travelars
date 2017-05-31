using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Travelars.DTO.Route;
using Travelars.Services.Abstract;
using Travelars.Services.Helpers;

namespace Travelars.Services.RouteServices
{
    public class RouteService : IRouteService
    {
        private const int AvailableHoursPerDay = 12;

        private readonly IMapper _mapper;

        public RouteService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RoutePlan GenerateRoute(RouteFilter requestModel)
        {
            var routePlan = _mapper.Map<RoutePlan>(requestModel);
            const double hoursLimit = AvailableHoursPerDay * 0.8;

            while (requestModel.StartTime.Date <= requestModel.EndTime.Date)
            {
                var dayActivity = new DayActivity
                {
                    Date = requestModel.StartTime,
                    Id = new Guid()
                };
                var hoursLeft = AvailableHoursPerDay;
                var place = GetRandomPlace(requestModel.City);
                //var recommendedTime = place.PlaceType.GetRecommendedHours();
                //while (recommendedTime <= hoursLeft)
                //{
                //    place = GetRandomPlace(requestModel.City);
                //    recommendedTime = place.PlaceType.GetRecommendedHours();
                //}

                //hoursLeft -= recommendedTime;
                dayActivity.Places.Add(place);
                if (hoursLeft <= hoursLimit)
                {
                    routePlan.SchedulePerDay.Add(dayActivity);
                }
            }

            return routePlan;
        }

        private PlaceVisit GetRandomPlace(string city)
        {
            throw new NotImplementedException();
        }
    }
}

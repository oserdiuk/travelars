using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GoogleApiService;
using GoogleApiService.Entities.Places.Search.NearBy.Request;
using GoogleApiService.Entities.Places.Search.Text.Request;
using GoogleApiService.Extensions;
using Travelars.DAL;
using Travelars.DTO.Route;
using Travelars.Services.Abstract;
using Travelars.Services.Helpers;

namespace Travelars.Services.RouteServices
{
    public class RouteService : IRouteService
    {
        private const int AvailableHoursPerDay = 12;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RouteService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public RoutePlan GenerateRoute(RouteFilter requestModel)
        {
            var routePlan = _mapper.Map<RoutePlan>(requestModel);
            const double hoursLimit = AvailableHoursPerDay * 0.8;

            while (requestModel.StartDate.Date <= requestModel.EndDate.Date)
            {
                var dayActivity = new DayActivity(requestModel.StartDate);
                var hoursLeft = AvailableHoursPerDay;
                var place = GetRandomPlace(requestModel.City, requestModel.PlaceTypes);

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

        private PlaceVisit GetRandomPlace(string city, IEnumerable<PlaceType> typesFilter)
        {
            var queryResult = GooglePlaces.NearBySearch.Query(new PlacesNearBySearchRequest
            {
                Keyword = city
            });

            var places = queryResult.Results.Where(
                place => typesFilter.Any(type => place.Types.Any(placeType => placeType.ToEnumString() == type.ToEnumString())));

            var placeVisit = _mapper.Map<PlaceVisit>(places.FirstOrDefault());
            FillWithDataFromDatabase(placeVisit);
            return placeVisit;
        }

        private void FillWithDataFromDatabase(PlaceVisit placeVisit)
        {
            var storedPlace = _unitOfWork.PlaceRepository.FirstOrDefault(p => p.PlaceId == placeVisit.PlaceId);
            placeVisit.
            
        }
    }
}

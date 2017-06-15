using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GoogleApiService;
using GoogleApiService.Entities.Places.Details.Request;
using GoogleApiService.Entities.Places.Details.Response;
using GoogleApiService.Entities.Places.Search.NearBy.Request;
using GoogleApiService.Entities.Places.Search.NearBy.Request.Enums;
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
        private const int AvailableHoursPerDay = 8;
        private const int MaxAvailablePoint = 100;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfigSettingsProvider _configSettingsProvider;

        public RouteService(IMapper mapper, IUnitOfWork unitOfWork, IConfigSettingsProvider configSettingsProvider)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configSettingsProvider = configSettingsProvider;
        }

        public RouteService()
        {

        }

        public RoutePlan GenerateRoute(RouteFilter requestModel)
        {
            var routePlan = _mapper.Map<RoutePlan>(requestModel);
            const double hoursLimit = AvailableHoursPerDay * 0.8;
            var startVisitPlaceDate = requestModel.StartDate;
            while (requestModel.StartDate.Date <= requestModel.EndDate.Date)
            {
                var dayActivity = new DayActivity(requestModel.StartDate);
                var hoursLeft = AvailableHoursPerDay;
                var place = GetRandomPlace(requestModel.City, requestModel.PlaceTypes);

                while (place.RecomendedTime.Hours <= hoursLeft)
                {
                    place.SetVisitTime(startVisitPlaceDate);
                    dayActivity.Places.Add(place);
                    startVisitPlaceDate = place.EndDateTime;

                    if (hoursLeft <= hoursLimit)
                    {
                        dayActivity.Places.Add(place);
                        hoursLeft -= place.RecomendedTime.Hours;
                    }

                    place = GetPlaceNearby(place.Name, requestModel.PlaceTypes, startVisitPlaceDate);
                }

                routePlan.SchedulePerDay.Add(dayActivity);
            }

            return routePlan;
        }

        private PlaceVisit GetPlaceNearby(string placeName, IEnumerable<PlaceType> typesFilter, DateTime startVisitDate)
        {
            var keyword = startVisitDate.IsDinnerTime() ? _configSettingsProvider.DinnerKeyword : string.Empty;

            var queryResult = GooglePlaces.NearBySearch.Query(new PlacesNearBySearchRequest
            {
                Name = placeName,
                Keyword = keyword,
                Rankby = Ranking.Distance
            });

            var places = string.IsNullOrWhiteSpace(keyword)
                ? queryResult.Results.Where(place => typesFilter.Any(
                           type => place.Types.Any(placeType => placeType.ToEnumString() == type.ToEnumString())))
                : queryResult.Results;
            var googlePlace = GooglePlaces.Details.Query(new PlacesDetailsRequest { PlaceId = places.ElementAt(1).PlaceId }).Result;
            var placeVisit = _mapper.Map<PlaceVisit>(googlePlace);
            FillWithDataFromDatabase(placeVisit);
            SetRating(placeVisit, googlePlace.Review);
            return placeVisit;
        }

        private PlaceVisit GetRandomPlace(string city, IEnumerable<PlaceType> typesFilter)
        {
            var queryResult = GooglePlaces.NearBySearch.Query(new PlacesNearBySearchRequest
            {
                Keyword = city
            });

            var places = queryResult.Results.Where(
                place => typesFilter.Any(type => place.Types.Any(placeType => placeType.ToEnumString() == type.ToEnumString())));
            var googlePlace = GooglePlaces.Details.Query(new PlacesDetailsRequest { PlaceId = places.FirstOrDefault().PlaceId }).Result;
            var placeVisit = _mapper.Map<PlaceVisit>(googlePlace);
            FillWithDataFromDatabase(placeVisit);
            SetRating(placeVisit, googlePlace.Review);
            return placeVisit;
        }

        private double SetRating(PlaceVisit placeVisit, IEnumerable<Review> placeReview)
        {
            var allVotes = _unitOfWork.VoteRepository.Get();
            var votesCount = placeVisit.UserVotes.Count + placeReview.Count();
            var votesSum = placeVisit.UserVotes.Sum(v => v.UserRate) + placeReview.Sum(r => r.Rating);
            var allVotesCount = allVotes.Count();
            var middleRate = votesSum / votesCount;
            var middleRateGeneral = allVotes.Sum(v => v.UserRate) / allVotesCount;

            var sumOfRates = allVotesCount * middleRateGeneral + votesCount * middleRate;
            var sumOfRateCount = allVotesCount + votesCount;
            var bayes = sumOfRates / sumOfRateCount;
            var numberInRating = bayes / MaxAvailablePoint;
            var rate = Math.Round(numberInRating, 2);
            return rate;
        }

        private void FillWithDataFromDatabase(PlaceVisit placeVisit)
        {
            var storedPlace = _unitOfWork.PlaceRepository.FirstOrDefault(p => p.PlaceId == placeVisit.PlaceId);
            placeVisit.RecomendedSeason = storedPlace.RecomendedSeason;
            placeVisit.RecomendedTime = storedPlace.RecomendedTime;
            placeVisit.RecommendedPartOfADay = storedPlace.RecommendedPartOfADay;
            placeVisit.Rating = storedPlace.UserRate;
        }
    }

    public interface IConfigSettingsProvider

    {
        string DinnerKeyword { get; set; }
    }
}

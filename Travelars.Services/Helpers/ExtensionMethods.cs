using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelars.DTO.Route;

namespace Travelars.Services.Helpers
{
    public static class ExtensionMethods
    {
        public static int GetRecommendedHours(this PlaceType placePlaceType)
        {
            if (placePlaceType == PlaceType.AmusementPark
                || placePlaceType == PlaceType.Park)
            {
                return 3;
            }

            if (placePlaceType == PlaceType.MovieTheater || placePlaceType == PlaceType.CityHall || placePlaceType == PlaceType.Church)
            {
                return 3;
            }

            if (placePlaceType == PlaceType.Museum
                || placePlaceType == PlaceType.CityHall
                || placePlaceType == PlaceType.Church
                || placePlaceType == PlaceType.ArtGallery
                || placePlaceType == PlaceType.Aquarium)
            {
                return 2;
            }

            if (placePlaceType == PlaceType.Cafe || placePlaceType == PlaceType.Restaurant || placePlaceType == PlaceType.Bar)
            {
                return 2;
            }

            if (placePlaceType == PlaceType.Bakery)
            {
                return 1;
            }

            if (placePlaceType == PlaceType.NightClub || placePlaceType == PlaceType.ShoppingMall || placePlaceType == PlaceType.Casino)
            {
                return 5;
            }

            return 1;
        }

        public static bool IsDinnerTime(this DateTime date)
        {
            return (date.TimeOfDay > new TimeSpan(9, 0, 0) && date.TimeOfDay < new TimeSpan(11, 0, 0))
                   || (date.TimeOfDay > new TimeSpan(13, 0, 0) && date.TimeOfDay < new TimeSpan(15, 0, 0))
                   || (date.TimeOfDay > new TimeSpan(17, 0, 0) && date.TimeOfDay < new TimeSpan(20, 0, 0));
        }
    }
}

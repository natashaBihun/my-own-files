using System.Collections.Generic;
using System.Linq;

namespace MapOfTheCity
{
    public class MapOfCity
    {
        public List<Place> Places;

        public MapOfCity() {
            Places = new List<Place>();
        }

        public Place GetMostPopularPlace()
        {
            Place mostPopularPlace = Places
                                        .Where(t => t is IRatingable)
                                        .Select(t => (IRatingable)t)
                                        .OrderByDescending(t => t.Rating)
                                        .Select(t => (Place)t)
                                        .FirstOrDefault();
            return mostPopularPlace;
        }

        public PlaceToEat GetNearestPlaceToEat(Place place)
        {
            return Places
                 .Where(t => t is PlaceToEat)
                 .Select(t => (PlaceToEat)t)
                 .OrderByDescending(t => t.GetDistance(place))
                 .FirstOrDefault();
        }

        public List<IRatingable> GetPlacesWithRating()
        {
            return Places
                    .Where(t => t is IRatingable)
                    .Select(t => (IRatingable)t)
                    .ToList();
        }

        public List<T> GetPlacesOfType<T>() where T : Place
        {
            return Places
                    .Where(t => t is T)
                    .Select(t => (T)t)
                    .ToList();
        }

        public List<IRatingable> GetSortedListOfPlacesByRating() {
            return Places
                        .Where(t => t is IRatingable)
                        .Select(t => (IRatingable)t)
                        .OrderByDescending(t => t.Rating)
                        .ToList();
        }
    }
}

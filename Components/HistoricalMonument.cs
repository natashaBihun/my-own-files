using System;

namespace MapOfTheCity
{
    public class HistoricalMonument : PlaceWithRating
    {
        private const string _historicalMonument = "Historical Monument";
        public override string TypeOfPlace { get { return _historicalMonument; } }       
        public HistoricalMonument(string name, double x, double y, float rating) 
            : base(name, x, y, rating) {

        }
    }
}

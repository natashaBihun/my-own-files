using System;

namespace MapOfTheCity
{
    public abstract class Place
    {
        private string _name;
        protected static int LastId = 0;
        public GeographicCoordinates Coordinates;
        public int Id { get; protected set; }    
        public abstract string TypeOfPlace { get;}
        public string Name {
            get {
                return _name;
            }
            set {
                if (value != null)
                    _name = value;
                else
                    throw new Exception("Name can't be null");
            }
        }
        
        public Place(string name, double x, double y) {
            LastId++;
            Id = LastId;
            Name = name;
            Coordinates = new GeographicCoordinates(x, y);
        }

        public double GetDistance(Place place) {
            return Math.Sqrt(
                        Math.Pow(place.Coordinates.X - Coordinates.X, 2.0) 
                        + Math.Pow(place.Coordinates.Y - Coordinates.Y, 2.0)
                        );
        }

        public override string ToString()
        {
            return string.Format($"{TypeOfPlace,-20} {Name,-20} \t {Coordinates} \t ");
        }
    }
}

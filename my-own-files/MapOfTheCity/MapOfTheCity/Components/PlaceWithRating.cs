using System;

namespace MapOfTheCity
{
    public class PlaceWithRating : Place, IRatingable
    {
        private float _rating;
        public override string TypeOfPlace { get; }
        public float Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if (value > 0 && value <= 5)
                    _rating = value;
                else
                    throw new Exception("Invalid Rating");
            }
        }

        public PlaceWithRating(string name, double x, double y, float rating) 
            : base(name, x, y) {
            Rating = rating;
        }

        public void Vote(float newMark)
        {
            this.Rating = (this.Rating + newMark) / 2;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format($"{Rating}\t");
        }
    }

}


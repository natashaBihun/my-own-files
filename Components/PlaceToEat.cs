using System;
using System.Collections.Generic;

namespace MapOfTheCity
{
    public class PlaceToEat :PlaceWithRating, ISchedulable
    {
        private const string _placeToEat = "Places To Eat";

        private int _openFrom;
        private int _openTo;

        public string ContactInfo;
        public override string TypeOfPlace { get { return _placeToEat; } }

        public int OpenFrom {
            get { return _openFrom; }
            set {
                if (value >= 0 && value <= 24) _openFrom = value;
                else throw new Exception("Wrong hours");
            }
        }
        public int OpenTo
        {
            get { return _openTo; }
            set
            {
                if (value >= 0 && value <= 24) _openTo = value;
                else throw new Exception("Wrong hours");
            }
        }

        public PlaceToEat(string name, double x, double y, string contactInfo, int openFrom, int openTo, float rating) 
            : base(name, x, y, rating) {

            ContactInfo = contactInfo.EmptyIfNull();
            OpenFrom = openFrom;
            OpenTo = openTo;
        }

        public bool IsOpen()
        {
            if (DateTime.Now.Hour >= OpenFrom && DateTime.Now.Hour < OpenTo) return true;
            else return false;
        }
        public override string ToString()
        {
            return base.ToString() + string.Format($"{ContactInfo} \t {OpenFrom} - {OpenTo}");
        }
    }
}

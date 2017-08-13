using System.Linq;

namespace MapOfTheCity
{
    public class PublicPlace : Place
    {
        private const string _publicPlace = "Public Place";
        public override string TypeOfPlace { get { return _publicPlace; }  }        

        public PublicPlace(string name, double x, double y) 
            : base (name, x, y) {
        }

    }
}

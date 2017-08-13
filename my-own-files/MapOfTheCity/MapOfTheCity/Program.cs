using System;
using System.Collections.Generic;
using System.Linq;

namespace MapOfTheCity
{
    class Program
    {
        static void Main(string[] args)
        {
            MapOfCity mapOfCity = new MapOfCity();

            AddPublicPlaces(mapOfCity);
            AddHistoricalMonuments(mapOfCity);
            AddPlacesToEat(mapOfCity);

            char operationNumber;

            do
            {
                Console.WriteLine(
                "_____________________________________" +
                "\nEnter operation number:" +
                "\n1) Display list of places" +
                "\n2) Display distance between two places" +
                "\n3) Display sorted list of places by rating" +
                "\n4) Display coordinates of most popular place" +
                "\n5) Vote the place" +
                "\n6) Get the nearest place to eat" +
                "\n7) Close programm\n"
                );

                operationNumber = char.Parse(Console.ReadLine());

                switch (operationNumber)
                {
                    case '1':
                        DisplayPlaces<Place>(mapOfCity.Places);
                        break;
                    case '2':
                        DisplayPlaces<Place>(mapOfCity.Places);
                        CalculateDistanceBetweenTwoPlaces(mapOfCity);
                        break;
                    case '3':
                        DisplaySortedListOfPlacesByrating(mapOfCity);
                        break;
                    case '4':
                        DisplayCoordinatesOfMostPopularPlace(mapOfCity);
                        break;
                    case '5':
                        VoteThePlace(mapOfCity);
                        break;
                    case '6':
                        List<PlaceToEat> placesToEat = mapOfCity.GetPlacesOfType<PlaceToEat>();
                        if (!placesToEat.IsEmpty())
                            DisplayNearestPlaceToEat(mapOfCity);
                        break;
                    case '7':
                        break;
                    default:
                        Console.WriteLine("Wrong number");
                        break;
                }
            } while (operationNumber != '7');
        }

        public static void AddPublicPlaces(MapOfCity map) {
            map.Places.Add(new PublicPlace("Park Shevchenka", 28.2474, 91.9158));
            map.Places.Add(new PublicPlace("Park Zhovtnevy", 25.9101, 92.6579));
            map.Places.Add(new PublicPlace("Botanical Garden", 27.9742, 93.6596));
        }

        public static void AddHistoricalMonuments(MapOfCity map)
        {
            map.Places.Add(new HistoricalMonument("Holy Spirit Cathedral", 28.8016, 94.6780, 4.8f));
            map.Places.Add(new HistoricalMonument("Ratusha", 29.1829, 95.4716, 4));
            map.Places.Add(new HistoricalMonument("House-Ship", 29.5311, 96.6796, 2));
        }

        public static void AddPlacesToEat(MapOfCity map)
        {
            map.Places.Add(new PlaceToEat("Potato House", 29.8967, 97.3362, "(0372) 51-24-00", 23, 8, 3));
            map.Places.Add(new PlaceToEat("Cafe Schiller", 28.6937, 94.8849, "066 444-47-61", 10, 24, 3));
            map.Places.Add(new PlaceToEat("NYSP", 26.9841, 99.0333, "050 379 7878", 10, 23, 5));
            map.Places.Add(new PlaceToEat("Pizza Monopoli", 29.1390, 83.4254, "099 339-33-93", 11, 18, 4.2f));
            map.Places.Add(new PlaceToEat("Veranda", 29.1390, 84.4254, "099 339-33-93", 8, 18, 3.9f));
        }

        public static void DisplayPlaces<T>(List<T> places)
        {
            for (int i = 0; i < places.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {places[i].ToString()}");
            }
        }

        public static void CalculateDistanceBetweenTwoPlaces(MapOfCity map){
            Console.Write("\nEnter number of first place: ");
            int idOfFirstPlace = int.Parse(Console.ReadLine()) - 1;
            idOfFirstPlace = IsIndexCorrect(idOfFirstPlace, map.Places.Count());

            Console.Write("Enter number of second place: ");
            int idOfSecondPlace = int.Parse(Console.ReadLine()) - 1;
            idOfSecondPlace = IsIndexCorrect(idOfSecondPlace, map.Places.Count());

            double distance = map.Places[idOfFirstPlace].GetDistance(map.Places[idOfSecondPlace]);
            Console.WriteLine($"\nDistance from {map.Places[idOfFirstPlace].Name} to {map.Places[idOfSecondPlace].Name} equals {distance}");
        }

        public static void DisplaySortedListOfPlacesByrating(MapOfCity map) {
            Console.WriteLine("\nSorted list of places by rating:");

            List<IRatingable> sortedPlaces = map.GetSortedListOfPlacesByRating();

            DisplayPlaces<IRatingable>(sortedPlaces);
        }

        public static void DisplayCoordinatesOfMostPopularPlace(MapOfCity map) {
            Console.Write("The most popular place: ");
            Place mostPopularPlace = map.GetMostPopularPlace();
            Console.WriteLine(mostPopularPlace.Coordinates);
        }

        public static void VoteThePlace(MapOfCity map)
        {
            List<IRatingable> places = map.GetPlacesWithRating();
            DisplayPlaces<IRatingable>(places);

            Console.Write("\nEnter number of place for putting new rating: ");
            int number = int.Parse(Console.ReadLine()) - 1;
            number = IsIndexCorrect(number, places.Count());

            Console.Write("Enter new rating (0,0 - 5,0): ");
            float newMark = float.Parse(Console.ReadLine());

            places[number].Vote(newMark);

            Console.WriteLine($"Place with new rating: {places[number]}");
        }

        public static void DisplayNearestPlaceToEat(MapOfCity map) {
            List<Place> publicPlaces = map.Places
                .Except(map.GetPlacesOfType<PlaceToEat>())
                .ToList();

            DisplayPlaces<Place>(publicPlaces);

            Console.Write("Enter number of your place: ");
            int number = int.Parse(Console.ReadLine()) - 1;
            number = IsIndexCorrect(number,publicPlaces.Count());

            PlaceToEat nearestPlaceToEat = map.GetNearestPlaceToEat(publicPlaces[number]);

            string isPlaceOpen = "closed";
            if(nearestPlaceToEat.IsOpen()) isPlaceOpen = "open";


            Console.WriteLine($"The nearest place to eat to {publicPlaces[number].Name} is {nearestPlaceToEat.Name} and it's {isPlaceOpen}");
        }

        public static int IsIndexCorrect(int index, int placesCount) {
            while (!index.IsIndexInRange(placesCount))
            {
                Console.WriteLine("Wrong index. Enter correct index");
                index = int.Parse(Console.ReadLine()) - 1;
            }
            return index;
        }

    }
}

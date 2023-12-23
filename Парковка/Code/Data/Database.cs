using System.Text.RegularExpressions;
using Парковка.Code.Domain;

namespace Парковка.Code.Data
{
    internal static class Database
    {
        public static Parking GetParkingData(string[] args)
        {
            string DBPath = args.ElementAtOrDefault(0) ?? string.Empty;
            int freeSpaces = ValidateDataBase(File.ReadAllText(DBPath));

            List<ParkingPlace> parkingPlaces = new List<ParkingPlace>();

            for (int i = 0; i < freeSpaces; i++)
            {
                ParkingPlace place = new ParkingPlace();
                parkingPlaces.Add(place);
            }

            Parking parking = new Parking(parkingPlaces);

            return parking;
        }

        public static int ValidateDataBase(string freeSpacesFromDB)
        {
            int freeSpaces;
            if (!Regex.IsMatch(freeSpacesFromDB, @"\d"))
            {
                Console.WriteLine("База данных составлена неверно");
                Environment.Exit(0);
            }
            freeSpaces = Convert.ToInt32(freeSpacesFromDB);
            return freeSpaces;
        }
    }
}
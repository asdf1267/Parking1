using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Парковка.Code.Domain
{
    internal class Parking
    {
        public List<ParkingPlace> ParkingPlaces { get; private set; }

        public Parking(List<ParkingPlace> parkingPlaces)
        {
            ParkingPlaces = parkingPlaces;
        }

        public Parking()
        {
        }

        public int GetFreePlaces()
        {
            int freePlaces = 0;
            for (int i = 0; i < ParkingPlaces.Count; i++)
            {
                if (ParkingPlaces[i].IsFree == true)
                    freePlaces++;
            }

            return freePlaces;
        }

        public bool isFree(string userUnputPlace)
        {
            return !int.TryParse(userUnputPlace, out int selectedPlaces) || selectedPlaces < 0 || selectedPlaces >= ParkingPlaces.Count || ParkingPlaces[selectedPlaces].IsFree == false;
        }
    }
}

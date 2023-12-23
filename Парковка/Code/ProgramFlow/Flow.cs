using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Парковка.Code.Domain;
using Парковка.Code.UI;

namespace Парковка.Code.ProgramFlow
{
    internal class Flow
    {
        public static void ProgramLogic(Parking parking)
        {
            while (true)
            {
                ConsoleInterface.ShowMessage("Добро пожаловать в систему платной парковки!");
                ConsoleInterface.ShowAllPlaces(parking.ParkingPlaces);

                ParkingPlace selectedPlace = GetUserInputPlace(parking);

                SetInOutTime(selectedPlace);

                TimeSpan parkingTime = selectedPlace.TimeOut - selectedPlace.TimeIn;

                ConsoleInterface.ShowMessage($"Время стоянки: {parkingTime}");
                double price = ParkingPlace.GetPrice(parkingTime);
                ConsoleInterface.ShowMessage("\nОбщая стоимость парковки: \n");
                ConsoleInterface.ShowMessage($"{price} рублей с вас");
                int freePlaces = parking.GetFreePlaces();

                ConsoleInterface.PrintConfirmation(selectedPlace.TimeIn, selectedPlace.TimeOut, parkingTime, price, freePlaces);//функция вывода подтверждения покупки
            }
        }

        private static ParkingPlace GetUserInputPlace(Parking parking)
        {
            ParkingPlace? selectedPlace = null;
            while (selectedPlace == null)
            {
                string userUnputPlace = ConsoleInterface.RequestData("Какое место хотите занять?");

                if (IsDigit(userUnputPlace))
                {
                    int index = Convert.ToInt32(userUnputPlace);
                    selectedPlace = parking.ParkingPlaces.ElementAtOrDefault(index);
                    if (selectedPlace != null && !selectedPlace.IsFree)
                    {
                        selectedPlace = null;
                        ConsoleInterface.ShowMessage("Место занято!");
                    }
                }
            }

            return selectedPlace;
        }

        private static bool IsDigit(string userUnputPlace)
        {
            return Regex.IsMatch(userUnputPlace, @"\d");
        }

        private static void SetInOutTime(ParkingPlace place)
        {
            place.IsFree = false;
            place.TimeIn = GetTimeIn();
            place.TimeOut = GetTimeOut();
        }


        private static DateTime GetTimeIn()
        {
            DateTime timeIn = new DateTime();
            timeIn = timeIn.AddHours(ConsoleInterface.GetInput("Введите время заезда (часы): "));
            timeIn = timeIn.AddMinutes(ConsoleInterface.GetInput("Введите время заезда (минуты): "));

            return timeIn;
        }
        private static DateTime GetTimeOut()
        {
            DateTime timeOut = DateTime.MinValue;

            timeOut = timeOut.AddHours(ConsoleInterface.GetInput("Введите время выезда (часы): "));
            timeOut = timeOut.AddMinutes(ConsoleInterface.GetInput("Введите время выезда (минуты): "));

            return timeOut;
        }
        
    }
}

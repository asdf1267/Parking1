using Парковка.Code.Domain;

namespace Парковка.Code.UI
{
    internal static class ConsoleInterface
    {
        public static void ShowMessage(string error)
        {
            Console.WriteLine(error);
        }

        public static void ShowAllPlaces(List<ParkingPlace> parkingPlaces)
        {
            for (int i = 0; i < parkingPlaces.Count; i++)
            {
                Console.WriteLine($"Парковочное место {i}\tСвободно: {parkingPlaces[i].IsFree}");
            }
        }

        public static string RequestData(string requestMessage)
        {
            Console.Write($"Введите {requestMessage}: ");

            return Console.ReadLine() ?? string.Empty;
        }
        public static void PrintConfirmation(DateTime timeIn, DateTime timeOut, TimeSpan parkngTime, double price, int freePlaces)
        {
            Console.WriteLine();
            Console.WriteLine("Подтверждение покупки:");
            Console.WriteLine($"Время заезда: {timeIn.TimeOfDay}");
            Console.WriteLine($"Время выезда: {timeOut.TimeOfDay}");
            Console.WriteLine($"Количество времени на парковке: {parkngTime}");
            Console.WriteLine($"Общая стоимость: {price} руб.");
            Console.WriteLine($"Кол-во свободных мест: {freePlaces}");
        }
        public static double GetInput(string message)
        {
            Console.Write(message);
            int parsed;
            string choice = Console.ReadLine() ?? string.Empty;
            while (!int.TryParse(choice, out parsed))
            {
                Console.Write(message);
                choice = Console.ReadLine() ?? string.Empty;
            }
            return parsed;
        }
    }
}

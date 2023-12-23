namespace Парковка.Code.Domain
{
    internal class ParkingPlace
    {
        public bool IsFree { get; set; } = true;
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }

        public static double GetPrice(TimeSpan parkingTime)
        {
            double price;

            if (parkingTime.Minutes >= 30)
            {
                price = (parkingTime.Hours + 1) * 50;
            }
            else
            {
                price = parkingTime.Hours * 50;
            }

            return price;
        }
    }
}
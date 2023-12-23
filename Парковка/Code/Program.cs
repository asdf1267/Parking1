using Парковка.Code.Data;
using Парковка.Code.Domain;
using Парковка.Code.ProgramFlow;
using Парковка.Code.UI;

namespace Парковка.Code {     class Program     {         static void Main(string[] args)         {             try
            {
                Parking parking = Database.GetParkingData(args);
                Flow.ProgramLogic(parking);
            }             catch (Exception ex)
            {
                ConsoleInterface.ShowMessage(ex.Message);
            }         }     } } 
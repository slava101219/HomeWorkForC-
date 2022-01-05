using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppForCSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            bool isWork = true;
            string choice;

            while (isWork)
            {
                ShowMenu(controller);
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.SendTrain();
                        break;
                    case "2":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("ошибка ввода");
                        break;
                }
            }
        }

        static void ShowMenu(Controller controller)
        {
            Console.Clear();
            Console.SetCursorPosition(40, 1);
            Console.Write("Билетов куплено:" + controller.TicketsCount);
            Console.SetCursorPosition(40, 2);
            Console.Write("Поездов отправлено:" + controller.TrainCount);
            Console.SetCursorPosition(40, 3);
            Console.WriteLine("поезд в " + controller.DepartureStation + ".");
            Console.WriteLine("1 - создать маршрут. 2 - выход.");
        }
    }

    class Controller
    {
        private DataBaseStation _stationController = new DataBaseStation();
        public int TicketsCount { get; private set; }
        public int TrainCount { get; private set; }
        public string DepartureStation { get; private set; } = "Moscow";

        public void SendTrain()
        {
            string destinationStation = CreateRoute();
            CreateTrain();
            Console.ReadKey();
            Console.Write("из " + DepartureStation + " ");
            int barLoadingLenght = 40;

            for(int i = 0; i < barLoadingLenght; i++)
            {
                Console.Write("-");
                Thread.Sleep(100);
            }

            Console.Write("поезд прибыл в " + destinationStation);
            Console.ReadKey();
            DepartureStation = destinationStation;
            TrainCount++;
        }
        public string CreateRoute()
        {
            Console.WriteLine("выбрать направление:");
            _stationController.ShowStations();
            string choice = Console.ReadLine();

            if(int.TryParse(choice, out int result))
            {
                if(result > 0 && result <= _stationController.GetCountStations() && _stationController.GetStation(result - 1) != DepartureStation)
                {
                    return _stationController.GetStation(result - 1);
                }
                else
                {
                    Console.WriteLine("ошибка ввода.");
                    return CreateRoute();
                }
            }
            else
            {
                Console.WriteLine("ошибка ввода.");
                return CreateRoute();
            }
        }

        public void CreateTrain()
        {
            Train train = new Train();
            TicketsCount += train.AmountTickets;
        }
    }

    class DataBaseStation
    {
        private List<string> _stations = new List<string>()
        {
            "Moscow", "London", "Paris", "Stambul", "Praha"
        };

        public string GetStation(int index)
        {
            return _stations[index];
        }

        public void ShowStations()
        {
            for(int i = 0; i < _stations.Count; i++)
            {
                Console.Write((i + 1) + ") " + _stations[i] + ". ");
            }
            Console.WriteLine();
        }

        public int GetCountStations()
        {
            return _stations.Count;
        }
    }

    class Train
    {
        private Random _random = new Random();
        public int AmountTickets { get; private set; }
        public int AmountCarriages { get; private set; }

        public Train()
        {
            int maxTickets = 101;
            AmountTickets = _random.Next(0, maxTickets);
            AmountCarriages = SetCarriage(AmountTickets);
        }

        public int SetCarriage(int tickets)
        {
            int carriageXapacity = 30;
            int carriages = tickets / carriageXapacity + 1;
            Console.WriteLine("Билетов куплено: " + tickets);
            Console.WriteLine("в вагоне 30 мест. Мы добавим " + carriages + " вагонов, для " + tickets + " человек.");
            return carriages;
        }
    }
}    

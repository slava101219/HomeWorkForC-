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
            string choice;
            bool isWork = true;
            CarServiceStation carServiceStation = new CarServiceStation();

            while(isWork == true)
            {
                Console.WriteLine("1) принять новую машину. 2) купить деталь. 3) просмотр склада. 4) выход.");
                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        carServiceStation.ServiceNewCustomer();
                        break;
                    case "2":
                        carServiceStation.BuySpare();
                        break;
                    case "3":
                        carServiceStation.ShowWarehouse();
                        break;
                    case "4":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
        }
    }
    
    class CarServiceStation
    {
        private Producer _producer = new Producer();
        private List<Spare> _warehouse = new List<Spare>();
        private int _money = 1000;

        public void BuySpare()
        {
            Console.WriteLine("выбрать можно из:");

            foreach(String name in _producer.GetNames())
            {
                Console.Write(name + ", ");
            }

            Console.WriteLine("введите номер выбранной запчасти.");
            string choiceSpare = Console.ReadLine();
            
            if(int.TryParse(choiceSpare, out int result))
            {
                if(result > 0 && result <= _producer.GetNames().Length)
                {
                    Spare spare = new Spare(result - 1);
                    if(_money >= spare.Price)
                    {
                        _money -= spare.Price;
                        _warehouse.Add(spare);
                        Console.WriteLine("Куплена " + spare.Name + ". Денег осталось: " + _money);
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно денег.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода.");
            }
        }

        public void ServiceNewCustomer()
        {
            CarCustomer carCustomer = new CarCustomer();
            Console.WriteLine("Новая тачка на ремонт! Требуется замена " + carCustomer.NeedSpareName + ". ");
            
            if(_warehouse.Contains(carCustomer.Spare)) 
            {
                int totalPrice = carCustomer.Spare.PriceReplacement + carCustomer.Spare.Price;
                Console.WriteLine("на складе есть необходимая деталь. Начинаем замену.");
                _money += totalPrice;
                Console.WriteLine("Мы выписали чек: стоимость детали - " + carCustomer.Spare.Price + ", стоимость ремонта - " + carCustomer.Spare.PriceReplacement);
                Console.WriteLine("Итого: " + totalPrice + ". на счету - " + _money);
                _warehouse.Remove(carCustomer.Spare);
            }
            else
            {
                Console.WriteLine("На складе нет этой детали.. Черт, мы упустили клиента..");
                _money -= carCustomer.Spare.PriceReplacement;
                Console.WriteLine("Мы понесли убытки в размере " + carCustomer.Spare.PriceReplacement + ". На счету: " + _money);
            }

            Console.ReadKey();
        }

        public void ShowWarehouse()
        {
            Console.Clear();
            Console.WriteLine("На счету: " + _money);
            Console.WriteLine("----------------------");

            foreach (Spare spare in _warehouse)
            {
                Console.WriteLine(spare.Name);
            }

            Console.WriteLine("----------------------");
        }
    }

    class Producer
    {
        private List<string> _names = new List<string>() { "фара", "Зеркало", "Масло", "Ремень", "Подшипник", "Сальник", "Фильтр" };
        private List<int> _prices = new List<int>() { 70, 80, 20, 10, 15, 10, 15 };
        private List<int> _pricesReplacement = new List<int>() { 20, 20, 15, 30, 30, 25, 25 };

        public string[] GetNames()
        {
            string[] arrayNames = new string[_names.Count];
            _names.CopyTo(arrayNames);
            return arrayNames;
        }

        public int[] GetPrices()
        {
            int[] arrayPrices = new int[_prices.Count];
            _prices.CopyTo(arrayPrices);
            return arrayPrices;
        }

        public int[] GetPricesReplacement()
        {
            int[] arrayPricesReplacement = new int[_pricesReplacement.Count];
            _pricesReplacement.CopyTo(arrayPricesReplacement);
            return arrayPricesReplacement;
        }
    }

    class Spare
    {
        private Producer _producer = new Producer();
        private static Random _random = new Random();
        
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int PriceReplacement { get; private set; }

        public Spare(int spareVariant)
        {
            Name = _producer.GetNames()[spareVariant];
            Price = _producer.GetPrices()[spareVariant];
            PriceReplacement = _producer.GetPricesReplacement()[spareVariant];
        }
        public Spare()
        {
            int spareVariant = _random.Next(0, _producer.GetNames().Length);
            Name = _producer.GetNames()[spareVariant];
            Price = _producer.GetPrices()[spareVariant];
            PriceReplacement = _producer.GetPricesReplacement()[spareVariant];
        }

        public override bool Equals(object obj)
        {
            if (obj is Spare spare)
            {
                return Name == spare.Name;
            }
            else
            {
                return false;
            }            
        }
    }

    class CarCustomer
    {
        public Spare Spare { get; private set; }
        public string NeedSpareName { get; private set; }

        public CarCustomer()
        {
            Spare = new Spare();
            NeedSpareName = Spare.Name;
        }
    }
}

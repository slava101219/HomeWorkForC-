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
            bool IsWork = true;
            CarServiceStation carServiceStation = new CarServiceStation();

            while(IsWork == true)
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
                        IsWork = false;
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
        private List<Spare> _warehouse = new List<Spare>();
        private int _money = 1000;

        public void BuySpare()
        {
            Console.WriteLine("выбрать можно из:");

            foreach(String name in Spare.GetNames())
            {
                Console.Write(name + ", ");
            }

            Console.WriteLine("введите номер выбранной запчасти.");
            string choiceSpare = Console.ReadLine();
            
            if(int.TryParse(choiceSpare, out int result))
            {
                if(result > 0 && result <= Spare.GetNames().Length)
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

    class Spare
    {
        static Random random = new Random();
        private static List<string> _names = new List<string>() { "фара", "Зеркало", "Масло", "Ремень", "Подшипник", "Сальник", "Фильтр" };
        private static List<int> _prices = new List<int>() { 70, 80, 20, 10, 15, 10, 15 };
        private static List<int> _pricesReplacement = new List<int>() { 20, 20, 15, 30, 30, 25, 25 };
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int PriceReplacement { get; private set; }

        public static string[] GetNames()
        {
            string[] arrayNames = new string[_names.Count];
            _names.CopyTo(arrayNames);
            return arrayNames;
        }

        public Spare(int spareVariant)
        {
            Name = _names[spareVariant];
            Price = _prices[spareVariant];
            PriceReplacement = _pricesReplacement[spareVariant];
        }
        public Spare()
        {
            int spareVariant = random.Next(0, _names.Count);
            Name = _names[spareVariant];
            Price = _prices[spareVariant];
            PriceReplacement = _pricesReplacement[spareVariant];
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
        public Spare Spare = new Spare();
        public string NeedSpareName;

        public CarCustomer()
        {
            NeedSpareName = Spare.Name;
        }
    }
}

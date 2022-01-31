﻿using System;
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

            foreach(Spare spare in _producer.GetSpares())
            {
                Console.Write(spare.ToString() + ", ");
            }

            Console.WriteLine("введите номер выбранной запчасти.");
            string choiceSpare = Console.ReadLine();
            
            if(int.TryParse(choiceSpare, out int result))
            {
                if(result > 0 && result <= _producer.GetSpares().Length)
                {
                    Spare spare = _producer.GetSpare(result - 1);
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
                Console.WriteLine("Дадим ему скидку в  размере 50, чтобы он вернулся.");
                int discount = 50;
                _money -= discount;
                Console.WriteLine("Мы понесли убытки в размере " + discount + ". На счету: " + _money);
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
        private static Random _random = new Random();
        private List<Spare> _spares = new List<Spare>() { new Spare(0), new Spare(1), new Spare(2), new Spare(3), new Spare(4), new Spare(5), new Spare(6) };

        public Spare GetSpare(int varianteSpare)
        {
            return _spares[varianteSpare];
        }

        public Spare GetRandomSpare()
        {
            return _spares[_random.Next(0, _spares.Count)];
        }

        public Spare[] GetSpares()
        {
            Spare[] arraySpares = new Spare[_spares.Count];
            _spares.CopyTo(arraySpares);
            return arraySpares;
        }
    }

    class Spare
    {
        private List<string> _names = new List<string>() { "фара", "Зеркало", "Масло", "Ремень", "Подшипник", "Сальник", "Фильтр" };
        private List<int> _prices = new List<int>() { 70, 80, 20, 10, 15, 10, 15 };
        private List<int> _pricesReplacement = new List<int>() { 20, 20, 15, 30, 30, 25, 25 };
        private Producer _producer = new Producer();
        private static Random _random = new Random();
        
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int PriceReplacement { get; private set; }

        public Spare(int spareVariant)
        {
            Name = _names[spareVariant];
            Price = _prices[spareVariant];
            PriceReplacement = _pricesReplacement[spareVariant];
        }
        public Spare()
        {
            int spareVariant = _random.Next(0, _names.Count);
            Name = _names[spareVariant];
            Price = _prices[spareVariant];
            PriceReplacement = _pricesReplacement[spareVariant];
        }

        public override string ToString()
        {
            return Name;
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
        private Producer _producer = new Producer();
        public Spare Spare { get; private set; }
        public string NeedSpareName { get; private set; }

        public CarCustomer()
        {
            Spare = _producer.GetRandomSpare();
            NeedSpareName = Spare.Name;
        }
    }
}

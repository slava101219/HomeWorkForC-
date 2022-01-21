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
            Aquarium aquarium = new Aquarium();
            string choice;
            bool isWork = true;
            
            while(isWork == true)
            {
                Console.WriteLine("1) любоваться рбками. 2) добавить рыбку в аквариум. 3) убрать рыбку из аквариума) 4) прекратить это все!");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":                        
                        aquarium.LookAtFish();
                        aquarium.ShowFish();
                        break;
                    case "2":
                        aquarium.AddFish();
                        aquarium.ShowFish();
                        break;
                    case "3":
                        aquarium.DeleteFish();
                        aquarium.ShowFish();
                        break;
                    case "4":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода.");
                        break;
                }
            }
                
        }
    }

    class Aquarium
    {
        private int maxFishInAquarium = 10;
        private List<Fish> _fish = new List<Fish>();

        public void AddFish()
        {
            if(_fish.Count < maxFishInAquarium)
            {
                Console.WriteLine("введите имя рыбки.");
                _fish.Add(new Fish(Console.ReadLine()));
            }
            else
            {
                Console.WriteLine("Аквариум переполнен((");
            }
            
        }

        public void DeleteFish()
        {
            Console.WriteLine("Введите номер удаляемой рыбки.");
            if(int.TryParse(Console.ReadLine(), out int result))
            {
                if (result > 0 && result < _fish.Count)
                {
                    _fish.RemoveAt(result - 1);
                }
                else
                {
                    Console.WriteLine("ошибка.. попробуйте снова.");
                }
            }
            else
            {
                Console.WriteLine("ошибка.. попробуйте снова.");
            }
        }

        public void LookAtFish()
        {
            foreach (Fish fish in _fish)
            {
                fish.GrowOld();               
            }
            Console.WriteLine("рыбки постарели.");
            CheckAndDeadFish();
        }

        public void CheckAndDeadFish()
        {
            for (int i = _fish.Count - 1; i >= 0; i--)
            {
                if (_fish[i].Age < 1)
                {
                    Console.WriteLine("рыбка" + _fish[i].Name + "умерла.");
                    _fish.RemoveAt(i);
                }
            }    
        }

        public void ShowFish()
        {
            Console.WriteLine("------------------");
            foreach(Fish fish in _fish)
            {
                Console.WriteLine(fish.ToString());
            }
            Console.WriteLine("------------------");
        }
    }

    class Fish
    {
        public String Name { get; private set; }
        public int Age { get; private set; }

        public Fish(string name)
        {
            Age = 10;
            Name = name;
        }

        public void GrowOld()
        {
            Age -= 1;
        }

        public override string ToString()
        {
            return Name + " - " + Age + " г.";
        }
    }
}

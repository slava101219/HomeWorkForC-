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
            Aquarium aquarium = new Aquarium();
            string choice;
            bool isWork = true;
            
            while(isWork == true)
            {
                aquarium.ShowFish();
                Console.WriteLine("1) любоваться рбками. 2) добавить рыбку в аквариум. 3) убрать рыбку из аквариума) 4) прекратить это все!");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":                        
                        aquarium.GrowOldFishes();
                        break;
                    case "2":
                        aquarium.AddFish();
                        break;
                    case "3":
                        aquarium.DeleteFish();
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
        private int _capacity = 10;
        private List<Fish> _fishes = new List<Fish>();

        public void AddFish()
        {
            if(_fishes.Count < _capacity)
            {
                Console.WriteLine("введите имя рыбки.");
                _fishes.Add(new Fish(Console.ReadLine()));
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
                if (result > 0 && result <= _fishes.Count)
                {
                    _fishes.RemoveAt(result - 1);
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

        public void GrowOldFishes()
        {
            foreach (Fish fish in _fishes)
            {
                fish.GrowOld();               
            }

            Console.WriteLine("рыбки постарели.");
            RemoveDeadFish();
        }

        public void RemoveDeadFish()
        {
            for (int i = _fishes.Count - 1; i >= 0; i--)
            {
                if (_fishes[i].IsDead)
                {
                    Console.WriteLine("рыбка " + _fishes[i].Name + " умерла.");
                    _fishes.RemoveAt(i);
                }
            }    
        }

        public void ShowFish()
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("------------------");

            foreach(Fish fish in _fishes)
            {
                Console.WriteLine(fish.ToString());
            }

            Console.WriteLine("------------------");
        }
    }

    class Fish
    {
        public bool IsDead => Age >= MaxAge;
        public int MaxAge { get; private set; } = 10;
        public String Name { get; private set; }
        public int Age { get; private set; }

        public Fish(string name)
        {
            Age = 0;
            Name = name;
        }

        public void GrowOld()
        {
            Age += 1;
        }

        public override string ToString()
        {
            return Name + " - " + Age + " г.";
        }
    }
}

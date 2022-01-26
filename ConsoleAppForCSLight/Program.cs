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
            Zoo zoo = new Zoo();
            zoo.Start(); 
        }
    }

    class AnimalZone
    {
        private List<List<Animal>> _cell = new List<List<Animal>>() 
        { 
            new List<Animal>() { new Bison(), new Bison() }, 
            new List<Animal>() { new Bull(), new Bull() },
            new List<Animal>() { new Horse(), new Horse(), new Horse() },
            new List<Animal>() { new Deer(), new Deer(), new Deer(), new Deer() } 
        };

        public void ShowInfo(int cellNumber)
        {
            Console.WriteLine("в клетке " + _cell[cellNumber].Count() + " животных. Из них " + CountingNumberMales(_cell[cellNumber]) + " самцы.");
            Console.WriteLine("Слышны звуки : " + _cell[cellNumber][0].ToString());
            Console.Write("Животным по ");

            foreach (Animal animal in _cell[cellNumber])
            {
                Console.Write(animal.Age + ", ");
            }

            Console.Write("лет соответственно.");
            Console.ReadKey();
        }

        public int CountingNumberMales(List<Animal> cell)
        {
            int malesCount = 0;

            foreach (Animal animal in cell)
            {
                malesCount += animal.Sex;
            }

            return malesCount;
        }

        public int GetCellCount()
        {
            return _cell.Count();
        }
    }

    class Zoo
    {
        private AnimalZone animalZone = new AnimalZone();
        public void Start()
        {
            bool isWork = true;
            String choice;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Выбери клетку для просмотра животных. Всего " + animalZone.GetCellCount() + " клетки. или exit для выхода.");
                choice = Console.ReadLine();

                if (int.TryParse(choice, out int result))
                {
                    if(result > 0 && result <= animalZone.GetCellCount())
                    {
                        animalZone.ShowInfo(result - 1);
                    }
                }
                else if (choice == "exit")
                {
                    isWork = false;
                }
            }
        }

        
    }

    class Animal
    {
        private static Random _random = new Random();
        private int _male = 1;
        private int _minAge = 1;
        private int _maxAge = 6;
        public int Sex { get; private set; }
        public int Age { get; private set; }

        public Animal()
        {
            Sex = _random.Next(0, _male + 1);
            Age = _random.Next(_minAge, _maxAge);
        }

        public void SetSexMale()
        {
            Sex = 1;
        }
    }

    class Bison : Animal
    {
        public Bison() : base()
        {
        }

        public override string ToString()
        {
            return "зубров - Э-э-э";
        }
    }

    class Bull : Animal
    {
        public Bull() : base()
        {
            SetSexMale();
        }

        public override string ToString()
        {
            return "быков - Му-у-у";
        }
    }

    class Horse : Animal
    {
        public Horse() : base()
        {
        }

        public override string ToString()
        {
            return "лошадей - Ии-го-го";
        }
    }

    class Deer : Animal
    {
        public Deer() : base()
        {   
        }

        public override string ToString()
        {
            return "оленей - О-о-о";
        }
    }
}

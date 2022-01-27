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

    class Cell
    {
        private List<Animal> _cell = new List<Animal>();

        public Cell(int animalVariant)
        {
            if (animalVariant == 1)
            {
                _cell = new List<Animal>() { new Bison(), new Bison() };
            }
            else if (animalVariant == 2)
            {
                _cell = new List<Animal>() { new Bull(), new Bull() };
            }
            else if (animalVariant == 3)
            {
                _cell = new List<Animal>() { new Horse(), new Horse(), new Horse() };
            }
            else if (animalVariant == 4)
            {
                _cell = new List<Animal>() { new Deer(), new Deer(), new Deer(), new Deer() };
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("в клетке " + _cell.Count() + " животных. Из них " + CountingNumberMales(_cell) + " самцы.");
            Console.WriteLine("Слышны звуки : " + _cell[0].ToString());
            Console.Write("Животным по ");

            foreach (Animal animal in _cell)
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
    }

    class Zoo
    {
        private List<Cell> _cells = new List<Cell>() { new Cell(1), new Cell(2), new Cell(3), new Cell(4)};
        public void Start()
        {
            bool isWork = true;
            String choice;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Выбери клетку для просмотра животных. Всего " + _cells.Count + " клетки. или exit для выхода.");
                choice = Console.ReadLine();

                if (int.TryParse(choice, out int result))
                {
                    if (result > 0 && result <= _cells.Count)
                    {
                        _cells[result - 1].ShowInfo();
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

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
            bool IsWork = true;
            String choice;

            while(IsWork)
            {
                Console.Clear();
                Console.WriteLine("Выбери клетку для просмотра животных. Всего 4 клетки. или exit для выхода.");
                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        zoo.ShowInfoCell(zoo.GetCell(choice));
                        break;
                    case "2":
                        zoo.ShowInfoCell(zoo.GetCell(choice));
                        break;
                    case "3":
                        zoo.ShowInfoCell(zoo.GetCell(choice));
                        break;
                    case "4":
                        zoo.ShowInfoCell(zoo.GetCell(choice));
                        break;
                    case "exit":
                        IsWork = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Zoo
    {
        private List<Animal> _bisons = new List<Animal>() { new Bison(), new Bison() };
        private List<Animal> _bulls = new List<Animal>() { new Bull(), new Bull() };
        private List<Animal> _horses = new List<Animal>() { new Horse(), new Horse(), new Horse() } ;
        private List<Animal> _deers = new List<Animal>() { new Deer(), new Deer(), new Deer(), new Deer() };

        public List<Animal> GetCell(string choice)
        {
            if (choice == "1")
            {
                return _bisons;
            }
            else if (choice == "2")
            {
                return _bulls;
            }
            else if (choice == "3")
            {
                return _horses;
            }
            else
            {
                return _deers;
            }
        }

        public void ShowInfoCell(List<Animal> cell)
        {
            Console.WriteLine("в клетке " + cell.Count + " животных. Из них " + CountingNumberMales(cell) + " самцы.");
            Console.WriteLine("Слышны звуки : " + cell[0].ToString());
            Console.Write("Животным по ");

            foreach(Animal animal in cell)
            {
                Console.Write(animal.GetAge() + ", ");
            }

            Console.Write("лет соответственно.");
            Console.ReadKey();
        }

        public int CountingNumberMales(List<Animal> cell)
        {
            int malesCount = 0;

            foreach (Animal animal in cell)
            {
                malesCount += animal.GetSex();
            }

            return malesCount;
        }
    }

    class Animal
    {
        static Random random = new Random();
        private int _male = 2;
        private int _minAge = 1;
        private int _maxAge = 6;
        protected int Sex;
        protected int Age { get; private set; }
        protected string Sound { get; private set; }

        public Animal()
        {
            Sex = random.Next(0, _male);
            Age = random.Next(_minAge, _maxAge);
        }

        public int GetSex()
        {
            return Sex;
        }

        public int GetAge()
        {
            return Age;
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
            Sex = 1;
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

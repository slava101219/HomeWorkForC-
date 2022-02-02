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
            DatabaseCriminals databaseCriminals = new DatabaseCriminals();
            bool isWork = true;
            string choice;

            while(isWork == true)
            {
                Console.WriteLine("1) показать всех преступников.");
                Console.WriteLine("2) показать разыскиваемых преступников, отсортированных по росту.");
                Console.WriteLine("3) показать разыскиваемых преступников, отсортированных по весу.");
                Console.WriteLine("4) показать разыскиваемых преступников, отсортированных по национальности.");
                Console.WriteLine("5) выход;");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        databaseCriminals.ShowAllCriminals();
                        break;
                    case "2":
                        databaseCriminals.СonclusionOnGrowth();
                        break;
                    case "3":
                        databaseCriminals.ConclusionOnWeight();
                        break;
                    case "4":
                        databaseCriminals.ConclusionOnNationality();
                        break;
                    case "5":
                        break;
                }
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }

        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public bool ServingSentence { get; private set; }

        public Criminal(string name, int growth, int weight, string nationality, bool servingSentence)
        {
            Name = name;
            Growth = growth;
            Weight = weight;
            Nationality = nationality;
            ServingSentence = servingSentence;
        }
        public override string ToString()
        {
            string serving;

            if (ServingSentence == true)
            {
                serving = "пойман";
            }
            else
            {
                serving = "на свободе";
            }

            return Name + " / " + Growth +  " см. / " + Weight + " кг. / " + "страна - " + Nationality + " / статус - " + serving;
        }
    }

    class DatabaseCriminals
    {
        private List<Criminal> _Criminals = new List<Criminal>() {
        new Criminal("Майкл", 180, 79, "Англия", false),
        new Criminal("Байрам", 158, 68, "Сербия", true),
        new Criminal("Джек", 167, 81, "Англия", true),
        new Criminal("Усама", 172, 85, "Саудовская Аравия", false),
        new Criminal("Пабло", 161, 70, "Колумбия", true),
        new Criminal("Джозеф", 172, 85, "Уганда", false),
        new Criminal("Роберт", 172, 85, "Америка", false),
        new Criminal("Алексис", 172, 85, "Америка", false)};

        public void ShowAllCriminals()
        {
            foreach(Criminal criminal in _Criminals)
            {
                Console.WriteLine(criminal.ToString());
            }
        }

        public void СonclusionOnGrowth()
        {
            Console.WriteLine("Ведите минимальный порог роста для поиска.");

            if(int.TryParse(Console.ReadLine(), out int result))
            {
                var filteredCriminals = _Criminals.Where(criminal => criminal.Growth >= result).Where(criminal => criminal.ServingSentence == false);

                foreach(Criminal criminal in filteredCriminals)
                {
                    Console.WriteLine(criminal.ToString());
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        public void ConclusionOnWeight()
        {
            Console.WriteLine("Ведите минимальный порог веса для поиска.");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                var filteredCriminals = _Criminals.Where(criminal => criminal.Weight >= result).Where(criminal => criminal.ServingSentence == false);

                foreach (Criminal criminal in filteredCriminals)
                {
                    Console.WriteLine(criminal.ToString());
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        public void ConclusionOnNationality()
        {
            Console.WriteLine("Ведите страну для поиска.");
            string nationality = Console.ReadLine();
            var filteredCriminals = _Criminals.Where(criminal => criminal.Nationality.ToUpper() == nationality.ToUpper()).Where(criminal => criminal.ServingSentence == false);

            foreach (Criminal criminal in filteredCriminals)
            {
                    Console.WriteLine(criminal.ToString());
            }
        }
    }
}

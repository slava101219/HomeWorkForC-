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
            DatabaseStews databaseStews = new DatabaseStews();
            bool isWork = true;
            string choice;
            
            while(isWork == true)
            {
                Console.WriteLine("1) показать годные 2) выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        databaseStews.ShowGoodProducts();
                        break;
                    case "2":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Stew
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public int expirationDate { get; private set; } = 30;

        public Stew(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public override string ToString()
        {
            string stew = Name + " / " + Date.ToShortDateString();
            return stew;
        }
    }

    class DatabaseStews
    {
        private List<Stew> _stews = new List<Stew>() {
        new Stew("Боярская", new DateTime(2021, 12, 12)),
        new Stew("Радость туриста", new DateTime(2022, 02, 05)),
        new Stew("Тушка", new DateTime(2022, 01, 21)),
        new Stew("Брюшко", new DateTime(2021, 09, 02)),
        new Stew("Коровья", new DateTime(2022, 01, 19)),
        new Stew("Телячья", new DateTime(2021, 12, 22)),
        new Stew("Бычья", new DateTime(2022, 02, 02)),
        new Stew("Лососья", new DateTime(2022, 01, 27)),
        new Stew("Домашняя", new DateTime(2021, 04, 24)),
        new Stew("Заграничная", new DateTime(2021, 11, 12))};

    public void ShowAllStews()
        {
            Console.Clear();
            Console.WriteLine("----------------------");

            foreach (Stew stew in _stews)
            {
                Console.WriteLine(stew.ToString());
            }

            Console.WriteLine("----------------------");
        }

        public void ShowGoodProducts()
        {
            ShowAllStews();
            Console.WriteLine("Годны :");
            double expirationDate = -30;
            DateTime lastExpirationDate = DateTime.Today.AddDays(expirationDate);
            var sortedStews = _stews.Where(stew => DateTime.Compare(stew.Date, lastExpirationDate) >= 0).OrderBy(stew => stew.Date).Reverse().ToList();
            ShowList(sortedStews);
        }

        public void ShowList(List<Stew> stews)
        {
            foreach(Stew stew in stews)
            {
                Console.WriteLine(stew.ToString());
            }
        }
    }
}

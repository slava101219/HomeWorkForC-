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
            databaseCriminals.ShowAllCriminals();
            databaseCriminals.Amnesty();
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public Crimes Crime { get; private set; }

        public Criminal(string name, Crimes crime)
        {
            Name = name;
            Crime = crime;
        }
    }

    enum Crimes
    {
        Антиправительственное,
        Мошенничество,
        Разбой,
        Хулиганчтво,
        Кража
    }
    class DatabaseCriminals
    {
        private List<Criminal> _criminals = new List<Criminal>() {
        new Criminal("Майкл", Crimes.Антиправительственное),
        new Criminal("Байрам", Crimes.Кража),
        new Criminal("Джек", Crimes.Мошенничество),
        new Criminal("Усама", Crimes.Разбой),
        new Criminal("Пабло", Crimes.Хулиганчтво),
        new Criminal("Джозеф", Crimes.Антиправительственное),
        new Criminal("Роберт", Crimes.Кража),
        new Criminal("Алексис", Crimes.Мошенничество)};

        public void ShowAllCriminals()
        {
            foreach(Criminal criminal in _criminals)
            {
                Console.WriteLine(criminal.Name + " / " + criminal.Crime);
            }
        }

        public void Amnesty()
        {
            Console.WriteLine("Под амнистию попали:");

            var amnestyCriminals = _criminals.Where(criminal => criminal.Crime == Crimes.Антиправительственное);

            foreach(Criminal criminal in amnestyCriminals)
            {
                Console.WriteLine(criminal.Name + " / " + criminal.Crime);
            }

            Console.WriteLine("После амнистии в тюрьме остались:");

            amnestyCriminals = _criminals.Except(amnestyCriminals);

            foreach(Criminal criminal in amnestyCriminals)
            {
                Console.WriteLine(criminal.Name + " / " + criminal.Crime);
            }
        }
    }
}

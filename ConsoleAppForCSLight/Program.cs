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
            DatabaseSoldiers databaseSoldiers = new DatabaseSoldiers();
            databaseSoldiers.TransferSoldiers();
            Console.ReadKey();
        }
    }

    enum Armament
    {
        Автомат,
        Пистолет,
        Пулемет,
        Граната
    }

    enum Rank
    {
        сержант,
        лейтенант,
        капитан,
        майор
    }

    class Soldier
    {
        public string Name { get; private set; }
        public Rank Rank { get; private set; }
        public Armament Armament { get; private set; }
        public int TermEmploy { get; private set; }


        public Soldier(string name, Rank rank, Armament armament, int termEmploy)
        {
            Name = name;
            Rank = rank;
            Armament = armament;
            TermEmploy = termEmploy;
        }

        public override string ToString()
        {
            string soldier = Name + " / " + Rank + " / " + Armament + " / служить еще " + TermEmploy + " месяцев" ;
            return soldier;
        }
    }

    class DatabaseSoldiers
    {
        private List<Soldier> _soldiers2 = new List<Soldier>(){
        new Soldier("Рембо", Rank.лейтенант, Armament.Пистолет, 17),
        new Soldier("Сталоне", Rank.капитан, Armament.Пулемет, 34),
        new Soldier("барк", Rank.сержант, Armament.Автомат, 3),
        new Soldier("Витька", Rank.сержант, Armament.Граната, 8),
        new Soldier("Вовка", Rank.сержант, Armament.Пистолет, 15) };
        private List<Soldier> _soldiers = new List<Soldier>() {
        new Soldier("Боря", Rank.капитан, Armament.Автомат, 12),
        new Soldier("Деня", Rank.лейтенант, Armament.Граната, 23),
        new Soldier("Макс", Rank.майор, Armament.Пистолет, 6),
        new Soldier("Димас", Rank.сержант, Armament.Пулемет, 5),
        new Soldier("Колян", Rank.лейтенант, Armament.Граната, 21),};

    public void ShowAllSoldiers(List <Soldier> soldiers)
        {
            Console.WriteLine("----------------------");

            foreach (Soldier soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }

            Console.WriteLine("----------------------");
        }

        public void TransferSoldiers()
        {
            ShowAllSoldiers(_soldiers);
            ShowAllSoldiers(_soldiers2);
            var sortedSoldierWithB = _soldiers.Where(soldier => soldier.Name.ToUpper().StartsWith("Б")).ToList();
            _soldiers2 = _soldiers2.Union(sortedSoldierWithB).ToList();
            _soldiers = _soldiers.Except(_soldiers2).ToList();
            ShowAllSoldiers(_soldiers);
            ShowAllSoldiers(_soldiers2);
        }
    }
}

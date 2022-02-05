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
            DatabasePlayers databasePlayers = new DatabasePlayers();
            bool isWork = true;
            string choice;
            
            while(isWork == true)
            {
                Console.WriteLine("1) топ по лвл 2) топ ро силе 3) выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        databasePlayers.ShowTop3ByLvl();
                        break;
                    case "2":
                        databasePlayers.ShowTop3ByPower();
                        break;
                    case "3":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Power { get; private set; }
        public int Lvl { get; private set; }

        public Player(string name, int power, int lvl)
        {
            Name = name;
            Lvl = lvl;
            Power = power;
        }

        public override string ToString()
        {
            string player = Name + " / " + Lvl + " лвл. / " + Power + " - силы";
            return player;
        }
    }

    class DatabasePlayers
    {
        private List<Player> _players = new List<Player>() {
        new Player("Майкл", 1000, 23),
        new Player("Байрам", 1500, 24),
        new Player("Джек", 25000, 49),
        new Player("Усама", 8000, 32),
        new Player("Пабло", 240000, 83),
        new Player("Джозеф", 510, 12),
        new Player("Роберт", 46000, 62),
        new Player("Алексис", 18000, 53),
        new Player("Дима", 320, 2),
        new Player("Василий", 4500, 43)};

    public void ShowAllPlayers()
        {
            Console.Clear();
            Console.WriteLine("----------------------");

            foreach (Player player in _players)
            {
                Console.WriteLine(player.ToString());
            }

            Console.WriteLine("----------------------");
        }

        public void ShowTop3ByLvl()
        {
            ShowAllPlayers();
            Console.WriteLine("Топ по лвл.");
            var sortedPlayers = _players.OrderBy(player => player.Lvl).Reverse().ToList();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(sortedPlayers[i].ToString());
            }
        }

        public void ShowTop3ByPower()
        {
            ShowAllPlayers();
            Console.WriteLine("Топ по силе.");
            var sortedPlayers = _players.OrderBy(player => player.Power).Reverse().ToList();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(sortedPlayers[i].ToString());
            }
        }
    }
}

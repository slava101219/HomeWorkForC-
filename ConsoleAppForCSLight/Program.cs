using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForCSLight
{
    class Program
    {

        static void Main(string[] args)
        {
            Database dataBasePlayers = new Database(new List<Player>());
            bool isWork = true;
            string choice;

            while (isWork)
            {
                ShowMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        dataBasePlayers.ShowPlayersDB();
                        break;
                    case "2":
                        Console.WriteLine("введите ник для нового игрока");
                        dataBasePlayers.AddPlayerDB(new Player(Console.ReadLine()));
                        break;
                    case "3":
                        Console.WriteLine("введите номер игрока для изменения статуса бана.");

                        if (int.TryParse(Console.ReadLine(), out int result))
                        {
                            dataBasePlayers.BannedPlayerDB(result);
                        }
                        else
                        {
                            Console.WriteLine("ошибка ввода.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("введите номер удаляемого игрока.");

                        if (int.TryParse(Console.ReadLine(), out int result2))
                        {
                            dataBasePlayers.DeletePlayerDB(result2);
                        }
                        else
                        {
                            Console.WriteLine("ошибка ввода.");
                        }
                        break;
                    case "5":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("пункт в меню не найден");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("1) вывод базы. 2) добавление игрока. 3) забанить/разбанить игрока. 4) удалить игрока. 5) выйти.");
        }


    }

    class Player
    {
        public int _lvl { get; private set; } = 1;
        public string _nickname { get; private set; }
        public bool _isBanned { get; private set; } = false;

        public Player(string nickname)
        {
            _nickname = nickname;
        }

        public void BannedPlayer()
        {
            _isBanned = !_isBanned;
        }
    }

    class Database
    {
        private List<Player> DBPlayers;

        public Database(List<Player> dBPlayers)
        {
            DBPlayers = dBPlayers;
        }

        public void ShowPlayersDB()
        {
            foreach(Player player in DBPlayers)
            {
                Console.Write((DBPlayers.IndexOf(player) + 1) + ") " + player._nickname + ", " + player._lvl + " lvl, ");
                if (player._isBanned == false)
                {
                    Console.WriteLine("не забанен.");
                }
                else
                {
                    Console.WriteLine("забанен.");
                }
            }
        }

        public void AddPlayerDB(Player player)
        {
            DBPlayers.Add(player);
        }

        public void BannedPlayerDB (int numberPlayer)
        {
            if(numberPlayer > 0 && numberPlayer <= DBPlayers.Count)
            {
                DBPlayers[numberPlayer - 1].BannedPlayer();
            }
            else
            {
                Console.WriteLine("игрок не найден");
            }          
        }

        public void DeletePlayerDB (int numberPlayer)
        {
            if (numberPlayer > 0 && numberPlayer <= DBPlayers.Count)
            {
                DBPlayers.RemoveAt(numberPlayer - 1);
            }
            else
            {
                Console.WriteLine("игрок не найден");
            }
        }
    }
}

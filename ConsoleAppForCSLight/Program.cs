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
            string choice;
            bool isWork = true;
            Database dataBase = new Database(new List<Player>());

            while (isWork)
            {
                ShowMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        dataBase.ShowPlayers();
                        break;
                    case "2":
                        dataBase.AddPlayer(new Player(Console.ReadLine()));
                        break;
                    case "3":
                        dataBase.BanPlayer(GetPlayerNumber());
                        break;
                    case "4":
                        dataBase.UnbanPlayer(GetPlayerNumber());
                        break;
                    case "5":
                        dataBase.DeletePlayer(GetPlayerNumber());
                        break;
                    case "6":
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
            Console.WriteLine("1) вывод базы. 2) добавление игрока. 3) забанить игрока. 4) разбанить игрока. 5) удалить игрока. 6) выход.");
        }

        static int GetPlayerNumber()
        {
            Console.WriteLine("введите номер игрока.");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }

    class Player
    {
        public int Lvl { get; private set; } = 1;
        public string Nickname { get; private set; }
        public bool IsBanned { get; private set; } = false;

        public Player(string nickname)
        {
            Nickname = nickname;
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private List<Player> _players;

        public Database(List<Player> players)
        {
            _players = players;
        }

        public void ShowPlayers()
        {
            for(int i = 0; i < _players.Count; i++)
            {
                Console.Write((i + 1) + ") " + _players[i].Nickname + ", " + _players[i].Lvl + " lvl, ");
                if (_players[i].IsBanned == false)
                {
                    Console.WriteLine("не забанен.");
                }
                else
                {
                    Console.WriteLine("забанен.");
                }
            }
        }

        public void AddPlayer(Player player)
        {
            Console.WriteLine("введите ник для нового игрока");
            _players.Add(player);
        }

        public void BanPlayer (int numberPlayer)
        {
            if (CheckPlayerExistence(numberPlayer))
            {
                _players[numberPlayer - 1].Ban();
            }
        }

        public void UnbanPlayer(int numberPlayer)
        {
            if (CheckPlayerExistence(numberPlayer))
            {
                _players[numberPlayer - 1].Unban();                
            }
        }

        public bool CheckPlayerExistence(int numberPlayer)
        {
            if (numberPlayer > 0 && numberPlayer <= _players.Count)
            {              
                return true;
            }
            else
            {
                Console.WriteLine("игрок не найден");
                return false;
            }
        }

        public void DeletePlayer (int numberPlayer)
        {
            if (CheckPlayerExistence(numberPlayer))
            {
                _players.RemoveAt(numberPlayer - 1);
            }
        }
    }
}

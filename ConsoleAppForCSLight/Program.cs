using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForCSLight
{
    class Program
    {
        static bool isWork = true;
        static Database dataBase = new Database(new List<Player>());

        static void Main(string[] args)
        {         
            string choice;

            while (isWork)
            {
                ShowMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        dataBase.ShowPlayersDB();
                        break;
                    case "2":
                        Console.WriteLine("введите ник для нового игрока");
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
                        Exit();
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

        static void Exit()
        {
            isWork = false;
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
        private List<Player> _dBPlayers;

        public Database(List<Player> dBPlayers)
        {
            _dBPlayers = dBPlayers;
        }

        public void ShowPlayersDB()
        {
            for(int i = 0; i < _dBPlayers.Count; i++)
            {
                Console.Write((i + 1) + ") " + _dBPlayers[i].Nickname + ", " + _dBPlayers[i].Lvl + " lvl, ");
                if (_dBPlayers[i].IsBanned == false)
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
            _dBPlayers.Add(player);
        }

        public void BanPlayer (int numberPlayer)
        {
            if (CheckPlayerExistence(numberPlayer))
            {
                _dBPlayers[numberPlayer - 1].Ban();
            }
        }

        public void UnbanPlayer(int numberPlayer)
        {
            if (CheckPlayerExistence(numberPlayer))
            {
                _dBPlayers[numberPlayer - 1].Unban();                
            }
        }

        public bool CheckPlayerExistence(int numberPlayer)
        {
            if (numberPlayer > 0 && numberPlayer <= _dBPlayers.Count)
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
                _dBPlayers.RemoveAt(numberPlayer - 1);
            }
        }
    }
}

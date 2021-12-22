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
            Player player = new Player(20);
            player.ShowInfo();
        }
    }

    class Player
    {
        public int Lvl;

        public Player(int lvl)
        {
            Lvl = lvl;
        }

        public void ShowInfo()
        {
            Console.WriteLine("игрок " + Lvl + " уровня.");
        }
    }
}

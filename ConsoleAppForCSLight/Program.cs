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
            Player player = new Player(30, 10, "$");
            Renderer render = new Renderer(player);
            render.DrowObject(player.X, player.Y, player.Logo);
        }
    }

    class Player
    {
        public int X;
        public int Y;
        public string Logo;

        public Player(int x, int y, string logo)
        {
            X = x;
            Y = y;
            Logo = logo;
        }
    }

    class Renderer
    {
        public Object Obj;
        public Renderer(Object obj)
        {
            Obj = obj;
        }

        public void DrowObject(int x, int y, string logo)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(logo);
        }
    }
}

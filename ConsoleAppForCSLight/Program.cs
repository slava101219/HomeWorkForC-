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
            Renderer render = new Renderer(new Player(30, 10, "$"));
            render.DrowObject();
        }
    }

    class Player
    {
        public int XСoordinate { get; }
        public int YСoordinate { get; }
        public string Logo { get; }

        public Player(int xСoordinate, int yСoordinate, string logo)
        {
            XСoordinate = xСoordinate;
            YСoordinate = yСoordinate;
            Logo = logo;
        }
    }

    class Renderer
    {
        private Player _player;
        public Renderer(Player player)
        {
            _player = player;
        }

        public void DrowObject()
        {
            Console.SetCursorPosition(_player.XСoordinate, _player.YСoordinate);
            Console.Write(_player.Logo);
        }
    }
}

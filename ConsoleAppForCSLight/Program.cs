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
            DrawBar(4, 10, 5);
        }
        static void DrawBar(int value, int maxValue, int position)
        {
            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += "#";
            }

            Console.SetCursorPosition(0, position);
            Console.Write("[" + bar);
            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += "_";
            }

            Console.Write(bar + "]");
        }
    }
}

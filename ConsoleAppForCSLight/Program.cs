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
            Console.CursorVisible = false;
            string hero = "S";
            int yHero = 30;
            int xHero = 10;
            int dyHero = 0;
            int dxHero = 0;
            bool isPlaying = true;
            string[,] map = FillAndDrowMap(20, 100);

            while (isPlaying)
            {
                Console.SetCursorPosition(yHero, xHero);
                Console.Write(hero);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch(key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            dxHero = -1; dyHero = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            dxHero = 1; dyHero = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            dxHero = 0; dyHero = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            dxHero = 0; dyHero = 1;
                            break;
                    }

                    if (map[dxHero + xHero, yHero + dyHero] != "|" && map[dxHero + xHero, yHero + dyHero] != "-")
                    {
                        Console.SetCursorPosition(yHero, xHero);
                        Console.Write(" ");
                        xHero += dxHero;
                        yHero += dyHero;
                        Console.SetCursorPosition(yHero, xHero);
                        Console.Write(hero);
                    }                   
                }
S               
            }
        }

        static string[,] FillAndDrowMap(int height, int width)
        {
            string[,] map = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        map[i, j] = "-";
                        Console.Write(map[i, j]);
                    }
                    else if (i == height-1)
                    {
                        map[i, j] = "-";
                        Console.Write(map[i, j]);
                    }
                    else if (i > 0 && i < height - 1 && j == 0 )
                    {
                        map[i, j] = "|";
                        Console.Write(map[i, j]);
                    }
                    else if (i > 0 && i < height - 1 && j == width - 1)
                    {
                        map[i, j] = "|";
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        map[i, j] = " ";
                        Console.Write(map[i, j]);
                    }
                }
                Console.WriteLine();
            }
            return map;
        }

        static void DrowMap (string[,] map)
        {
            int strngsInMap = map.GetUpperBound(0) + 1;
            int charsInString = map.Length / strngsInMap;
            for (int i = 0; i < strngsInMap; i++)
            {
                for (int j = 0; j < charsInString; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

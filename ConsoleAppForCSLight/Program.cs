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
            string wordForExit = "exit";
            string inputWord;
            Console.WriteLine("Введите \"exit\" для выхода.");
            inputWord = Console.ReadLine();
            while (inputWord != wordForExit)
            {
                Console.WriteLine("Еще раз. Введите \"exit\" для выхода.");
                inputWord = Console.ReadLine();
            }

        }
        
    }
}

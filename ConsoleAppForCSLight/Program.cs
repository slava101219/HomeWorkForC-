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
            string name;
            string myChar;
            int lemgthName;
            int iterator = 0;
            string stringWithChars;
            Console.WriteLine("ваше имя?");
            name = Console.ReadLine();
            Console.WriteLine("выбери знак.");
            myChar = Console.ReadLine();

            while (myChar.Length > 1 || myChar.Length < 1)
            {
                Console.WriteLine("выбери 1 знак.");
                myChar = Console.ReadLine();
            }
            stringWithChars = myChar;
            lemgthName = name.Length;

            while (lemgthName+1 != iterator++)
            {
                stringWithChars += myChar;
            }

                Console.WriteLine(stringWithChars + "\n" + myChar + name + myChar + "\n" + stringWithChars);                      
        }       
    }
}

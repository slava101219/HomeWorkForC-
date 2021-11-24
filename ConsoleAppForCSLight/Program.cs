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
            string stringWithChars = "";
            Console.WriteLine("ваше имя?");
            name = Console.ReadLine();
            Console.WriteLine("выбери знак.");
            myChar = Console.ReadLine();

            while (myChar.Length > 1 || myChar.Length < 1)
            {
                Console.WriteLine("выбери 1 знак.");
                myChar = Console.ReadLine();
            }
            
            for (int i = 0; name.Length + 2 != i; i++)
            {
                stringWithChars += myChar;
            }

            Console.WriteLine(stringWithChars);
            Console.WriteLine(myChar + name + myChar);
            Console.WriteLine(stringWithChars);
        }       
    }
}

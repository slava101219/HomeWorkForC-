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
            string password = "qwerty1234";
            string inputWord;
            int tryCount = 3;
            Console.WriteLine("введите пароль! у вас " + tryCount + " попытки");
            inputWord = Console.ReadLine();

            while (password != inputWord && tryCount > 1)
            {
                --tryCount;
                Console.WriteLine("введите пароль, у вас " + tryCount + " попыток.");
                inputWord = Console.ReadLine();
            }

            if (password == inputWord)
            {
                Console.WriteLine("Верный пароль!");
            }
            else
            {
                Console.WriteLine("Аккаунт заблокирован!");
            }
        }
    }
}

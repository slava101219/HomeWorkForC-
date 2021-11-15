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
            string messegeUser;
            Console.WriteLine("Введите сообщение, которое выведется 10 раз.");
            messegeUser = Console.ReadLine();
            for (int i = 1; i<=10; i++)
            {
                Console.WriteLine(messegeUser + i);
            }

        }
        
    }
}

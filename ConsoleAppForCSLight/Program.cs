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
            int messegeCount;
            int iteratorMessege = 0;
            Console.WriteLine("сколько раз вывести \"Это сообщение\" сообщение?");
            messegeCount = Convert.ToInt32(Console.ReadLine());
            while (messegeCount>0)
            {
                iteratorMessege++;
                Console.WriteLine("Это сообщение " + iteratorMessege + "-е");
                messegeCount--;
            }

        }
        
    }
}

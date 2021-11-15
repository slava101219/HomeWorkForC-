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
            int grannyCount;
            int waitingOfHour;
            int waitingOfMinute;
            int waitTime = 10;
            int howManyMinutesPerHour = 60;
            Console.WriteLine("введите кол-во старушек");
            grannyCount = Convert.ToInt32(Console.ReadLine());
            waitingOfMinute = (grannyCount * waitTime) % howManyMinutesPerHour;
            waitingOfHour = (grannyCount * waitTime) / howManyMinutesPerHour;
            Console.WriteLine("вы должны отстоять в очереди " + waitingOfHour + " часов и " + waitingOfMinute + " минут.");
        }
        
    }
}

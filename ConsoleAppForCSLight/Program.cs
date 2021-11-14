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
            int grannyCount, hour, minute;
            int waitTime = 10;
            Console.WriteLine("введите кол-во старушек");
            grannyCount = Convert.ToInt32(Console.ReadLine());
            minute = (grannyCount * waitTime) % 60;
            hour = (grannyCount * waitTime - minute) / 60;
            Console.WriteLine("вы должны отстоять в очереди " + hour + " часов и " + minute + " минут.");
        }
        
    }
}

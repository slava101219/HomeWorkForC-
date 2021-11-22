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
            int distance;
            int maxDistance = 98;
            int speed = 7;
            for ( distance = speed; distance<=maxDistance; distance+=speed)
            {
                Console.WriteLine(distance);
            }                      
        }       
    }
}

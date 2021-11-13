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
            int sizeForSeries = 3;
            int numberOfPictures = 52;
            int unnecessaryPictures = 52 % 3;
            int numberOfFullSeries = (52 - unnecessaryPictures) / 3;
            Console.WriteLine(unnecessaryPictures);
            Console.WriteLine(numberOfFullSeries);
        }
        
    }
}

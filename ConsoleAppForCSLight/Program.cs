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
            double usdCount = 1000;
            double eurCount = 1000;
            double changeUsdCount;
            double exchangeRate = 0.88;
            Console.WriteLine("usd : " + usdCount + " eur : " + eurCount);
            Console.WriteLine("сколько меняем доларов?");
            changeUsdCount = Convert.ToDouble(Console.ReadLine());
            usdCount -= changeUsdCount;
            eurCount = eurCount + changeUsdCount * exchangeRate;
            Console.WriteLine("usd : " + usdCount + " eur : " + eurCount);

        }
        
    }
}

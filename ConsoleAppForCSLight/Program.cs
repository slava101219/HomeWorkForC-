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
            ConvertStringAndReturnNumber();
        }

        static int ConvertStringAndReturnNumber()
        {
            int returnValue = 0;
            bool exitFromMethod = false;
              
            while (exitFromMethod == false)
            {
                string inputString = Console.ReadLine();
                exitFromMethod = int.TryParse(inputString, out returnValue);
            }

            return returnValue;
        }
    }
}
